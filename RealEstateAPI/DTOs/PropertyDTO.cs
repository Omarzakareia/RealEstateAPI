namespace RealEstateAPI.DTOs;
public class PropertyDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }  
    public string? Description { get; set; }  
    public decimal? Price { get; set; }  
    public int? Area { get; set; }  
    public int? Bedrooms { get; set; }  
    public int? Bathrooms { get; set; }  
    public int? PropertyTypeId { get; set; } 
    public string? PropertyTypeName { get; set; }  
    public int? LocationId { get; set; }  
    public string? LocationName { get; set; }  
    public string? PaymentPlan { get; set; }  
    public bool? IsFeatured { get; set; }  
    public int? DeveloperId { get; set; }  
    public string? DeveloperName { get; set; }  
    public int? ProjectId { get; set; }  
    public string? ProjectName { get; set; }  
    public string? BackgroundImage { get; set; }  
    public ICollection<PropertyImageDTO>? Images { get; set; } = new List<PropertyImageDTO>(); 
    public string? ContactNumber { get; set; }  
}
public class PropertyImageDTO
{
    public int Id { get; set; }
    public string? Url { get; set; }  
}
public class PropertyCardDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ProjectName { get; set; }
    public decimal? Price { get; set; }
    public int? Bedrooms { get; set; }
    public int? Bathrooms { get; set; }
    public int? Area { get; set; }
    public string? LocationName { get; set; }
    public string PropertyTypeName { get; set; }
    public string? BackgroundImage { get; set; }
    public string? ContactNumber { get; set; }
}
public class AddPropertyDTO
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Area { get; set; }
    public int? Bedrooms { get; set; }
    public int? Bathrooms { get; set; }
    public int PropertyTypeId { get; set; }
    public int LocationId { get; set; }
    public string? PaymentPlan { get; set; }
    public bool? IsFeatured { get; set; }
    public string? ContactNumber { get; set; }
    public int DeveloperId { get; set; }
    public int ProjectId { get; set; }
    public string? BackgroundImage { get; set; }
    public ICollection<int>? AmenityIds { get; set; }
    public ICollection<int>? PropertyImageIds { get; set; }
    public ICollection<int>? CallRequestIds { get; set; }
}
