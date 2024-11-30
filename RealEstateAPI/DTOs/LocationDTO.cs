namespace RealEstateAPI.DTOs;
public class LocationDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? BackgroundImage { get; set; }
    public int? ProjectCount { get; set; }
    public int? PropertyCount { get; set; }
    public double? Latitude { get; set; }   
    public double? Longitude { get; set; }    
    public ICollection<SimplePropertyDTO>? Properties { get; set; }
    public ICollection<SimpleProjectDTO>? Projects { get; set; }
}
public class SimplePropertyDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal? Price { get; set; }
    public int? Area { get; set; }
    public string? BackgroundImage { get; set; }
}
public class SimpleProjectDTO
{
    public int Id { get; set; }
    public string? ProjectTitle { get; set; }
    public string? BackgroundImage { get; set; }
    public int? PropertyCount { get; set; }
}
public class LocationCardDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }        
    public string? BackgroundImage { get; set; }
    public int? ProjectCount { get; set; }
    public int? PropertyCount { get; set; }
}
public class AddLocationDTO
{
    public string? Name { get; set; }         
    public string? BackgroundImage { get; set; }
    public double? Latitude { get; set; }    
    public double? Longitude { get; set; }    
}
