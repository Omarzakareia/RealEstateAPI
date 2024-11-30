using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Specifications;
namespace RealEstate.Repository;
public static class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> StartQuery, ISpecification<T> Spec)
    {
        var Query = StartQuery; // _dbContext.Products
        // Criteria = p => p.Id == id
        if (Spec.Criteria != null)
        {
            Query = Query.Where(Spec.Criteria);
        }
        if (Spec.IsPaginationEnabled)
        {
            Query = Query.Skip(Spec.Skip).Take(Spec.Take);
        }
        Query = Spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));
        return Query;
    }
}
