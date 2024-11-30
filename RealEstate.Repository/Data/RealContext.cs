using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;
using System.Reflection;
namespace RealEstate.Repository.Data;
public class RealContext : DbContext
{
    public RealContext(DbContextOptions<RealContext> options):base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }
    public DbSet<ProjectImage> ProjectImages { get; set; }
    public DbSet<CallRequest> CallRequests { get; set; }
    public DbSet<ProjectHighlight> ProjectHighlights { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }
    public DbSet<PropertyType> PropertyTypes { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
}
