using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Common.Middlewares
{
  public class JwtMiddleware(RequestDelegate next)
  {
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
      if (!context.Request.Path.StartsWithSegments("/api/auth"))
      {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
          var handler = new JwtSecurityTokenHandler();

          if (handler.ReadToken(token) is JwtSecurityToken tokenAsJson)
          {
            var claims = tokenAsJson.Claims.ToDictionary(c => c.Type, c => c.Value);
            context.Items["Id"] = claims["id"];
            context.Items["Username"] = claims["username"];
            await _next(context);
          }
        }
      }
      else
      {
        await _next(context);
      }
    }
  }
}