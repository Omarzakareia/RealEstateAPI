using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Repositories__Interfaces_;
using RealEstate.Core.Specifications;
using RealEstate.Repository.Data;
namespace RealEstate.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly RealContext _dbContext;
    public GenericRepository(RealContext dbContext) // Ask CLR for creating object from dbcontext implicitly
    {
        _dbContext = dbContext;
    }
    #region without spec
    public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _dbContext.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);
    #endregion
    private IQueryable<T> ApplySpec(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
    }
    public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec)
    {
        //return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), Spec).ToListAsync();
        return await ApplySpec(Spec).ToListAsync();
    }
    public async Task<T> GetEntityWithSpecAsync(ISpecification<T> Spec)
    {
        return await ApplySpec(Spec).FirstOrDefaultAsync();
    }
    //public async Task<int> GetCountWithSpecAsync(ISpecification<T> Spec)
    //{
    //    return await ApplySpec(Spec).CountAsync();
    //}
    //public async Task<IReadOnlyList<T>> GetTopThreeAsync(ISpecification<T> Spec)
    //{
    //    var query = ApplySpec(Spec).Take(3);
    //    return await ApplySpec(Spec).ToListAsync();
    //}
    public async Task AddAsync(T item)
    {
        await _dbContext.AddAsync(item);
    }
    public void Delete(T item) => _dbContext.Set<T>().Remove(item);
    public void Update(T item) => _dbContext.Set<T>().Update(item);
}
