using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Core.Entities;
namespace RealEstate.Repository.Configurations;
public class CallRequestConfigurations : IEntityTypeConfiguration<CallRequest>
{
    public void Configure(EntityTypeBuilder<CallRequest> builder)
    {
        // Primary Key
        builder.HasKey(cr => cr.Id);

        // Property configurations
        builder.Property(cr => cr.Name)
            .IsRequired()
            .HasMaxLength(100); // Set max length for the Name field

        builder.Property(cr => cr.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20); // Set max length for the PhoneNumber field

        builder.Property(cr => cr.RequestDate)
            .HasDefaultValueSql("GETDATE()"); // Set default value for RequestDate (current date/time)

        // Relationships
        builder.HasOne(cr => cr.Property)
            .WithMany(p => p.CallRequests) // Assuming Property has ICollection<CallRequest> CallRequests
            .HasForeignKey(cr => cr.PropertyId);

        builder.HasOne(cr => cr.Project)
            .WithMany(p => p.CallRequests) // Assuming Project has ICollection<CallRequest> CallRequests
            .HasForeignKey(cr => cr.ProjectId);
    }
}
