using System.Linq.Expressions;
namespace RealEstate.Core.Specifications;
public class BaseSpecification<T> : ISpecification<T> where T : class
{
    public BaseSpecification()     // Get All
    {
    }
    public BaseSpecification(Expression<Func<T, bool>> criteriaExpression)     // Get By ID
    {
        Criteria = criteriaExpression;
    }
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
    public void ApplyPagination(int skip, int take)
    {
        IsPaginationEnabled = true;
        Skip = skip;
        Take = take;
    }
    public int Take { get; set; }
    public int Skip { get; set; }
    public bool IsPaginationEnabled { get; set; }
}
