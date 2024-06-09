using Microsoft.EntityFrameworkCore;
using Reboot.DB.Domain.Context;

namespace Reboot.API;

public class Program
{
    public static void Main(string[] args)
    {
        DotNetEnv.Env.Load();
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<RebootDatabaseContext>();
            db.Database.Migrate();
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .ConfigureAppConfiguration(
                (hostingContext, config) =>
                {
                    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile($"Ocelot.{env}.json", false, true);
                });
    }
}
