using RealEstate.Core.Entities;
namespace RealEstate.Core.Specifications;
public class CallRequestSpecifications : BaseSpecification<CallRequest>
{
    public CallRequestSpecifications()
    {
        // Include related entities
        Includes.Add(l => l.Project);
        Includes.Add(l => l.Property);
    }
    public CallRequestSpecifications(int id) : base(location => location.Id == id)
    {
        Includes.Add(l => l.Project);
        Includes.Add(l => l.Property);
    }
}
