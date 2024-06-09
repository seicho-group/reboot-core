using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Reboot.DB.Domain.Context;

namespace Reboot.API;

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
        services.AddMvc();
        services.AddOcelot(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseCors("*");
        app.UseOcelot().Wait();
    }
}
