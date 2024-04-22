using DEMO.Domain.Entities;
using DEMO.Persistence.Data;
using DEMO.Persistence.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace DEMO.Client.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var typeConfigurations = Assembly.GetExecutingAssembly()
            .GetTypes().Where(x => (x.BaseType?.IsGenericType ?? false)
                                   && x.BaseType.GetGenericTypeDefinition() == typeof(ApplicationEntityConfiguration<>));

        foreach (var typeConfiguration in typeConfigurations)
        {
            var config = Activator.CreateInstance(typeConfiguration) as IMapping;
            config?.ApplyConfiguration(modelBuilder);
        }

        base.OnModelCreating(modelBuilder);
    }
}