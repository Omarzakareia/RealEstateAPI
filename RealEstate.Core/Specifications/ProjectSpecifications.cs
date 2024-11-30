using RealEstate.Core.Entities;
namespace RealEstate.Core.Specifications;
public class ProjectSpecifications : BaseSpecification<Project>
{
    public ProjectSpecifications()
    {
        Includes.Add(l => l.Location);
        Includes.Add(l => l.Properties);
        Includes.Add(l => l.Developer);
        Includes.Add(l => l.CallRequests);
        Includes.Add(l => l.ProjectHighlights);
        Includes.Add(l => l.ProjectImages);
        Includes.Add(l => l.ProjectType);

    }
    public ProjectSpecifications(int id ): base(project => project.Id == id)
    {
        Includes.Add(l => l.Location);
        Includes.Add(l => l.Properties);
        Includes.Add(l => l.Developer);
        Includes.Add(l => l.CallRequests);
        Includes.Add(l => l.ProjectHighlights);
        Includes.Add(l => l.ProjectImages);
        Includes.Add(l => l.ProjectType);
    }

}
