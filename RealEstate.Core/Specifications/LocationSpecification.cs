using RealEstate.Core.Entities;
using RealEstate.Core.Specifications;
public class LocationSpecification : BaseSpecification<Location>
{
    public LocationSpecification()
    {
        // Include related entities
        Includes.Add(l => l.Projects);
        Includes.Add(l => l.Properties);
    }
    public LocationSpecification(int id) : base(location => location.Id == id)      
    {
        Includes.Add(l => l.Projects);
        Includes.Add(l => l.Properties);
    }
}
