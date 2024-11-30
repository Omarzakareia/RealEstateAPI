namespace RealEstate.Core.Entities;
public class PropertyImage
{
    public int? Id { get; set; }  // Unique identifier for the image
    public string? Url { get; set; }  // URL of the image
    public int? PropertyId { get; set; }  // Foreign key to the property
    public Property? Property { get; set; }  // Navigation property back to the property
}
