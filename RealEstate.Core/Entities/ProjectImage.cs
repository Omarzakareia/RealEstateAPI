namespace RealEstate.Core.Entities;
public class ProjectImage
{
    public int? Id { get; set; }                  // Unique identifier for the image
    public string? Url { get; set; }               // URL or path to the image file
    public int? ProjectId { get; set; }            // Foreign key to the Project
    public Project? Project { get; set; }          // Navigation property to the Project
}
