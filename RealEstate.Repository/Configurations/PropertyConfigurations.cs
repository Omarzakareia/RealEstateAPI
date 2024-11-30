using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class PropertyConfigurations : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {     
        builder.HasKey(p => p.Id);// Primary Key

        builder.Property(p => p.Title) // Property configurations
            .HasMaxLength(100) // Set a max length for the Title field
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(1000); // Optional max length for Description

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)"); // Precision for price

        builder.Property(p => p.Area)
            .IsRequired(); // Area in square meters

        builder.Property(p => p.Bedrooms)
            .IsRequired();

        builder.Property(p => p.Bathrooms)
            .IsRequired();

        builder.Property(p => p.PaymentPlan)
            .HasMaxLength(200); // Optional max length for PaymentPlan

        builder.Property(p => p.IsFeatured)
            .HasDefaultValue(false); // Default value for IsFeatured

        builder.Property(p => p.ContactNumber)
            .HasMaxLength(20); // Set max length for ContactNumber

        builder.Property(p => p.BackgroundImage)
            .HasMaxLength(500); // Background image URL/path length

        // Relationships
        builder.HasOne(p => p.Location)
            .WithMany(l => l.Properties) // Proper inverse navigation property for Location
            .HasForeignKey(p => p.LocationId)
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior to prevent cascade deletes

        builder.HasOne(p => p.Developer)
            .WithMany(d => d.Properties) // Assuming Developer entity has ICollection<Property> Properties
            .HasForeignKey(p => p.DeveloperId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when a developer is deleted

        builder.HasOne(p => p.Project)
            .WithMany(pr => pr.Properties) // Assuming Project entity has ICollection<Property> Properties
            .HasForeignKey(p => p.ProjectId) // Define the foreign key for the ProjectId
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete for project association

        // Collection configurations
        builder.HasMany(p => p.Images)
            .WithOne(i => i.Property)
            .HasForeignKey(i => i.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.PropertyType)
            .WithMany()
            .HasForeignKey(p => p.PropertyTypeId);
    }
}
