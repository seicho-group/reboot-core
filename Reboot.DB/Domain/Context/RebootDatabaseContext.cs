using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Reboot.DB.Domain.Entities;

namespace Reboot.DB.Domain.Context;

public class RebootDatabaseContext : DbContext
{
    public RebootDatabaseContext()
    {
        Env.TraversePath().Load(".env");
    }
    
    public DbSet<PhoneFabric> PhoneFabrics { get; set; }
    public DbSet<PhoneSeries> PhoneSeries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        optionsBuilder.UseNpgsql($"" +
                                 $"Host={Environment.GetEnvironmentVariable("HOST")};" +
                                 $"Port=5433;" +
                                 $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};" +
                                 $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
                                 $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}");
    }
}
