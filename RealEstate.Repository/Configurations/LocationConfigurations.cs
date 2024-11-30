using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class LocationConfigurations : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        // Primary Key
        builder.HasKey(l => l.Id);

        // Property configurations
        builder.Property(l => l.Name)
            .HasMaxLength(200) // Set max length for Name
            .IsRequired(); // Name is required

        builder.Property(l => l.Latitude)
            .HasColumnType("decimal(9,6)"); // Latitude with precision for coordinates

        builder.Property(l => l.Longitude)
            .HasColumnType("decimal(9,6)"); // Longitude with precision for coordinates

        // Relationships
        builder.HasMany(l => l.Properties)
            .WithOne(p => p.Location)
            .HasForeignKey(p => p.LocationId)
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete for location properties

        builder.HasMany(l => l.Projects)
            .WithOne(pr => pr.Location)
            .HasForeignKey(pr => pr.LocationId) // Assuming Project has LocationId as foreign key
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete for location projects
    }
}
