using RealEstateAPI.DTOs;
namespace RealEstate.Core.DTOs;
public class DeveloperDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? LogoName { get; set; }
    public string? Logo { get; set; }
    public string? Description { get; set; }
    public List<ProjectDTO>? Projects { get; set; } // Include a list of ProjectDTO
    public List<PropertyDTO>? Properties { get; set; } // Include a list of PropertyDTO
}

public class DeveloperCardDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public string? Description { get; set; }
    public int? ProjectCount { get; set; }
    public int? PropertyCount { get; set; }
}

public class AddDeveloperDTO
{
    public string? Name { get; set; }
    public string? LogoName { get; set; }
    public string? Logo { get; set; }
    public string? Description { get; set; }
}
