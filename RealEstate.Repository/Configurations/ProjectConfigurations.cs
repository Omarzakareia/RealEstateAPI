using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class ProjectConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProjectTitle)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.ProjectName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.ProjectArea)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.UnitAreas)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.UnitTypes)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.UnitPrice)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.PricePerSquareMeter)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.PricePerMeter)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.About)
            .IsRequired(false);

        builder.Property(p => p.PaymentMethods)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.BackgroundImage)
            .HasMaxLength(255)
            .IsRequired(false);

        // Relationships configuration
        builder.HasOne(p => p.Developer)
            .WithMany(d => d.Projects)
            .HasForeignKey(p => p.DeveloperId)
            .OnDelete(DeleteBehavior.SetNull); // Assuming DeveloperId can be null

        builder.HasOne(p => p.Location)
          .WithMany(l => l.Projects)
          .HasForeignKey(p => p.LocationId);

        // Collection configurations
        builder.HasMany(p => p.Properties)
            .WithOne()
            .HasForeignKey(prop => prop.ProjectId) // Assuming a foreign key in the Property entity
            .OnDelete(DeleteBehavior.Cascade); // Or other delete behavior

        builder.HasMany(p => p.ProjectImages)
            .WithOne()
            .HasForeignKey(pi => pi.ProjectId) // Assuming a foreign key in the ProjectImage entity
            .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(p => p.ProjectType)         // Project has one ProjectType
            .WithMany()                         // ProjectType can have many Projects
            .OnDelete(DeleteBehavior.SetNull);
    }
}
