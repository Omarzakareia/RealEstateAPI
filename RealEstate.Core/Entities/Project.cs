namespace RealEstate.Core.Entities;
public class Project
{
    public int? Id { get; set; }
    public string? ProjectTitle { get; set; }
    public string? ProjectName { get; set; }
    public int? DeveloperId { get; set; }
    public Developer? Developer { get; set; }
    public string? ProjectArea { get; set; }
    public string? UnitAreas { get; set; }
    public string? UnitTypes { get; set; }
    public string? UnitPrice { get; set; }
    public string? StartingPrice { get; set; }
    public string? Status { get; set; }
    public string? PricePerSquareMeter { get; set; }
    public string? PricePerMeter { get; set; }
    public string? About { get; set; }
    public string? PaymentMethods { get; set; }
    public int? LocationId { get; set; }
    public Location? Location { get; set; }  
    public string? BackgroundImage { get; set; }
    public int? ProjectTypeId { get; set; }
    public ProjectType? ProjectType { get; set; }
    public ICollection<Amenity>? Amenities { get; set; } = new List<Amenity>();
    public ICollection<Property>? Properties { get; set; } = new List<Property>();
    public ICollection<ProjectImage>? ProjectImages { get; set; } = new List<ProjectImage>();
    public ICollection<CallRequest>? CallRequests { get; set; } = new List<CallRequest>();
    public ICollection<ProjectHighlight>? ProjectHighlights { get; set; } = new List<ProjectHighlight>();

}
