using System.Linq.Expressions;
namespace RealEstate.Core.Specifications;
public interface ISpecification<T> where T : class
{
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }
    public bool IsPaginationEnabled { get; set; }
}
