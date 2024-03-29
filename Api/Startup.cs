using System.Text;
using Api.Common;
using Api.Common.Interfaces;
using Api.Common.Middlewares;
using Api.Common.Services;
using Api.Modules.AppTasks;
using Api.Modules.Auth;
using Api.Modules.Interfaces;
using Api.Modules.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();
      services.AddControllers();

      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

      services.AddTransient<IAppTaskService, AppTaskService>();
      services.AddScoped<IAppTaskService, AppTaskService>();

      services.AddTransient<IUsersService, UserService>();
      services.AddScoped<IUsersService, UserService>();

      services.AddTransient<IAuthService, AuthService>();
      services.AddScoped<IAuthService, AuthService>();

      services.AddTransient<IPasswordHashingService, PasswordHashingService>();
      services.AddScoped<IPasswordHashingService, PasswordHashingService>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
        });

      services.AddCors();

      services.AddAuthorization();

      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddAutoMapper(typeof(MappingProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors(builder => {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
      });
      app.UseMiddleware<ErrorHandlerMiddleware>();
      app.UseMiddleware<JwtMiddleware>();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(config =>
      {
        config.MapControllers();
      });
    }
  }
}
