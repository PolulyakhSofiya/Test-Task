using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotlineParcer
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddDbContext<Context>(options =>
        options.UseSqlite(this.Configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseMvc();
    }
  }
}
