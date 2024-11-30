using RealEstate.Core.Repositories__Interfaces_;
using RealEstate.Core;
using System.Collections;
using RealEstate.Repository.Data;
namespace RealEstate.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly RealContext _dbContext;
    private Hashtable _repositories;
    public UnitOfWork(RealContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new Hashtable();
    }
    public async Task<int> CompleteAsync()
        => await _dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync()
        => await _dbContext.DisposeAsync();

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;
        if (!_repositories.ContainsKey(type))
        {
            var Repository = new GenericRepository<TEntity>(_dbContext);
            _repositories.Add(type, Repository);
        }
        return _repositories[type] as IGenericRepository<TEntity>;
    }
}
