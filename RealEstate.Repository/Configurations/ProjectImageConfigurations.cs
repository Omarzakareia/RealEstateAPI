using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class ProjectImageConfigurations : IEntityTypeConfiguration<ProjectImage>
{
    public void Configure(EntityTypeBuilder<ProjectImage> builder)
    {
        // Primary Key
        builder.HasKey(pi => pi.Id);

        // Property configurations
        builder.Property(pi => pi.Url)
            .IsRequired() // URL is required
            .HasMaxLength(500); // Max length for the image URL/path

        // Relationships
        builder.HasOne(pi => pi.Project)
            .WithMany(p => p.ProjectImages) 
            .HasForeignKey(pi => pi.ProjectId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when a project is deleted
    }
}
