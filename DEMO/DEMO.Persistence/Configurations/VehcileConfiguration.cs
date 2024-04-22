using DEMO.Domain.Entities;
using DEMO.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DEMO.Persistence.Configurations;

public class VehcileConfiguration : ApplicationEntityConfiguration<Vehicle>
{
    protected override void PostConfigure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        base.PostConfigure(builder);
    }
}