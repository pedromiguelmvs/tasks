using Newtonsoft.Json;

namespace Api.Common.Middlewares
{
  public class ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory log)
  {

    private readonly RequestDelegate _next = next;

    private readonly ILogger _log = log.CreateLogger("CustomErrorHandler");

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        _log.LogError($"Error: {ex.Message}");
        _log.LogError($"Stack: {ex.StackTrace}");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(new { ex.Message, ex.Data }));
      }
    }
  }
}