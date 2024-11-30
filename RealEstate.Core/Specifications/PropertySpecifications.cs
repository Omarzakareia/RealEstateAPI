using RealEstate.Core.Entities;
namespace RealEstate.Core.Specifications;
public class PropertySpecifications : BaseSpecification<Property>
{
    public PropertySpecifications()
    {
        Includes.Add(p => p.Location);
        Includes.Add(p => p.Developer);
        Includes.Add(p => p.PropertyType);
        Includes.Add(p => p.Project);
        Includes.Add(p => p.Images);
        Includes.Add(p => p.CallRequests);
    }
    public PropertySpecifications(int id) : base(property => property.Id == id)
    {
        Includes.Add(p => p.Location);
        Includes.Add(p => p.Developer);
        Includes.Add(p => p.PropertyType);
        Includes.Add(p => p.Project);
        Includes.Add(p => p.Images);
        Includes.Add(p => p.CallRequests);
    }
}
