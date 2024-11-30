namespace RealEstate.Core.Entities;
public class Developer
{
    public int? Id { get; set; }
    public string? Name { get; set; }  // E.g., "Al Marasem"
    public string? LogoName { get; set; }  // E.g., "Al Marasem"
    public string? Logo { get; set; }  // URL or path to the developer's logo image
    public string? Description { get; set; }  // Brief description of the developer
    public ICollection<Project>? Projects { get; set; } = new List<Project>();  // Projects by this developer
    public ICollection<Property>? Properties { get; set; } = new List<Property>();  // List of all properties (units) developed by this developer
}
