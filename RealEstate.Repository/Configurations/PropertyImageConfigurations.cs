using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class PropertyImageConfigurations : IEntityTypeConfiguration<PropertyImage>
{
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        builder.HasKey(pi => pi.Id); // Primary Key

        builder.Property(pi => pi.Url)   // Property configurations
            .IsRequired()    // URL is required
            .HasMaxLength(500);   // Max length for the image URL/path

        builder.HasOne(pi => pi.Property)  // Relationships
            .WithMany(p => p.Images) // Assuming Property has a collection of PropertyImages
            .HasForeignKey(pi => pi.PropertyId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when a property is deleted
    }
}
