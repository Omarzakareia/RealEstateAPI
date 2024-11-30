using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class DeveloperConfigurations : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        // Primary Key
        builder.HasKey(d => d.Id);

        // Property configurations
        builder.Property(d => d.Name)
            .HasMaxLength(200) // Set max length for Developer's Name
            .IsRequired(); // Developer Name is required

        builder.Property(d => d.LogoName)
            .HasMaxLength(200); // Optional max length for Logo Name

        builder.Property(d => d.Logo)
            .HasMaxLength(500); // Optional max length for Logo URL/Path

        builder.Property(d => d.Description)
            .HasMaxLength(1000); // Optional max length for Description

        // Relationships
        builder.HasMany(d => d.Projects)
            .WithOne(p => p.Developer)
            .HasForeignKey(p => p.DeveloperId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when a developer is deleted

        builder.HasMany(d => d.Properties)
            .WithOne(p => p.Developer)
            .HasForeignKey(p => p.DeveloperId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when a developer is deleted
    }
}
