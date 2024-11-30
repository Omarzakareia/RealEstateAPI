using RealEstate.Core.Entities;
namespace RealEstate.Repository.Data;
public class RealContextSeed
{
    public static async Task SeedProjectTypes(RealContext dbContext)
    {
        if (!dbContext.ProjectTypes.Any())
        {
            dbContext.ProjectTypes.AddRange(
                new ProjectType { Name = "Residential" },
                new ProjectType { Name = "Vacation" },
                new ProjectType { Name = "Commercial" },
                new ProjectType { Name = "Medical" }
            );
            await dbContext.SaveChangesAsync();
        }
    }
    public static async Task SeedPropertyTypes(RealContext dbContext)
    {
        if (!dbContext.PropertyTypes.Any())
        {
            dbContext.PropertyTypes.AddRange(
                new PropertyType { Name = "Apartment" },
                new PropertyType { Name = "Duplex" },
                new PropertyType { Name = "Studio" },
                new PropertyType { Name = "Town House" },
                new PropertyType { Name = "Twin House" },
                new PropertyType { Name = "Pent House" },
                new PropertyType { Name = "Villa" },
                new PropertyType { Name = "Office" },
                new PropertyType { Name = "Store" },
                new PropertyType { Name = "Chalet" },
                new PropertyType { Name = "Chalet with garden" },
                new PropertyType { Name = "Pharmacy" },
                new PropertyType { Name = "Clinic" },
                new PropertyType { Name = "Laboratory" }
            );
            await dbContext.SaveChangesAsync();
        }
    }
}
