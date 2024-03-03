using Api.Modules.AppTasks;
using Api.Modules.Interfaces;
using Api.Modules.Users;
using Microsoft.EntityFrameworkCore;

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
      // services.AddSwaggerGen();
      services.AddEndpointsApiExplorer();
      services.AddControllers();

      services.AddTransient<IAppTaskService, AppTaskService>();
      services.AddScoped<IAppTaskService, AppTaskService>();

      services.AddTransient<IUsersService, UserService>();
      services.AddScoped<IUsersService, UserService>();

      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddAutoMapper(typeof(MappingProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseRouting();

      // app.UseAuthentication();
      // app.UseAuthorization();

      app.UseEndpoints(config =>
      {
        config.MapControllers();
      });
    }
  }
}
