using RealEstate.Core.Specifications;
namespace RealEstate.Core.Repositories__Interfaces_;
public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);    // Get by Id 
    Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec);
    Task<T> GetEntityWithSpecAsync(ISpecification<T> Spec);
    Task AddAsync(T entity);                       
    void Delete(T item);
    void Update(T item);
    //Task<int> GetCountWithSpecAsync(ISpecification<T> Spec);
    //Task<IReadOnlyList<T>> GetTopThreeAsync(ISpecification<T> spec);
}
