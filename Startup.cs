using Api.Common.IService;
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
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      services.AddControllers();

      services.AddTransient<IService, AppTaskService>();
      services.AddScoped<IService, AppTaskService>();

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
