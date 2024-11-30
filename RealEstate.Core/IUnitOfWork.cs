using RealEstate.Core.Repositories__Interfaces_;
namespace RealEstate.Core;
public interface IUnitOfWork : IAsyncDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> CompleteAsync();
}
