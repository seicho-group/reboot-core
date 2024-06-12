using Reboot.DB.Domain.Context;

namespace Reboot.Entities;
public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<RebootDatabaseContext>();
        services.AddCors(options =>
        {
            options.AddPolicy("*", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("*");

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
