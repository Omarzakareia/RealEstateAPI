namespace RealEstate.Core.Entities;
public class Property
{
    public int? Id { get; set; }
    public string? Title { get; set; }  
    public string? Description { get; set; }  
    public decimal? Price { get; set; } 
    public int? Area { get; set; }  // Area in square meters
    public int? Bedrooms { get; set; }  
    public int? Bathrooms { get; set; }
    public int? PropertyTypeId { get; set; }
    public PropertyType? PropertyType { get; set; }  // Type: Apartment, Villa, etc.
    public int? LocationId { get; set; }      
    public Location? Location { get; set; }
    public string? PaymentPlan { get; set; }
    public bool? IsFeatured { get; set; }  // Featured property status
    public int? DeveloperId { get; set; }
    public Developer? Developer { get; set; }  // Associated developer
    public int? ProjectId { get; set; }  // Foreign key for the associated project
    public Project? Project { get; set; }  // Associated project details
    public string? BackgroundImage { get; set; }
    public ICollection<PropertyImage>? Images { get; set; } = new List<PropertyImage>();   // Images for the property
    public string? ContactNumber { get; set; }  // Contact number for the property
    public ICollection<CallRequest>? CallRequests { get; set; } = new List<CallRequest>();  // Requests related to this property
}
