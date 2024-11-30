namespace RealEstate.Core.Entities;
public class Location
{
    public int Id { get; set; }              // Unique identifier for the location
    public string? Name { get; set; }         // Name of the location (e.g., city or area)
    public double? Latitude { get; set; }     // Latitude for mapping
    public double? Longitude { get; set; }    // Longitude for mapping
    public string? BackgroundImage { get; set; }         // Name of the location (e.g., city or area)

    // Navigation properties
    public ICollection<Property>? Properties { get; set; } = new List<Property>(); // Properties in this location
    public ICollection<Project>? Projects { get; set; } = new List<Project>(); // Projects in this location
}
