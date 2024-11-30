using RealEstate.Core.Entities;
namespace RealEstate.Core.Specifications;
public class DeveloperSpecification : BaseSpecification<Developer>
{
    public DeveloperSpecification()
    {
        Includes.Add(l => l.Projects);
        Includes.Add(l => l.Properties);
    }
    public DeveloperSpecification(int id) : base(Developer => Developer.Id == id)
    {
        Includes.Add(l => l.Projects);
        Includes.Add(l => l.Properties);
    }
}
