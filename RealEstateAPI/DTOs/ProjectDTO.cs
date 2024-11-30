namespace RealEstateAPI.DTOs;
public class ProjectDTO
{
    public int Id { get; set; }
    public string? ProjectTitle { get; set; }
    public string? ProjectName { get; set; }
    public string DeveloperName { get; set; }  
    public string LocationName { get; set; }   
    public string ProjectTypeName { get; set; } 
    public string? ProjectArea { get; set; }
    public string? UnitAreas { get; set; }
    public string UnitTypes { get; set; }
    public string? StartingPrice { get; set; }
    public string Status { get; set; }
    public string? PricePerSquareMeter { get; set; }
    public string? PricePerMeter { get; set; }
    public string? About { get; set; }
    public string? PaymentMethods { get; set; }
    public string? BackgroundImage { get; set; }
    public ICollection<AmenityDTO>? Amenities { get; set; } 
    public ICollection<PropertyDTO> Properties { get; set; } 
    public ICollection<ProjectImageDTO>? ProjectImages { get; set; } 
    public ICollection<CallRequestDTO>? CallRequests { get; set; } 
    public ICollection<ProjectHighlightDTO>? ProjectHighlights { get; set; } 
}
public class ProjectImageDTO
{
    public int Id { get; set; }        
    public string Url { get; set; }      
    public int ProjectId { get; set; }   
}
public class ProjectCardDTO
{
    public int Id { get; set; }
    public string ProjectTitle { get; set; }
    public int DeveloperId { get; set; }
    public string DeveloperName { get; set; }
    public string StartingPrice { get; set; }
    public string Status { get; set; }
    public int LocationId { get; set; }
    public string LocationName { get; set; }
    public string? BackgroundImage { get; set; }
    public int ProjectTypeId { get; set; }
    public string ProjectTypeName { get; set; }
}
public class DeveloperProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class LocationProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class AddProjectDTO
{
    public string ProjectTitle { get; set; }
    public string ProjectName { get; set; }
    public int DeveloperId { get; set; } 
    public int LocationId { get; set; }  
    public int ProjectTypeId { get; set; } 
    public string? ProjectArea { get; set; }
    public string? UnitAreas { get; set; }
    public string? UnitTypes { get; set; }
    public string? StartingPrice { get; set; }
    public string? Status { get; set; }
    public string? PricePerSquareMeter { get; set; }
    public string? PricePerMeter { get; set; }
    public string? About { get; set; }
    public string? PaymentMethods { get; set; }
    public string? BackgroundImage { get; set; }
    public ICollection<int>? AmenityIds { get; set; } 
    public ICollection<int>? ProjectImageIds { get; set; } 
    public ICollection<int>? ProjectHighlightIds { get; set; } 
}