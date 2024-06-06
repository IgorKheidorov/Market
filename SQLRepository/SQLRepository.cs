using Microsoft.EntityFrameworkCore;
using SuperMarketEntities.Interfaces;

namespace SQLRepository;

public class SQLRepository<TEntity> : IRepository<TEntity> where TEntity: class
{
    internal HyperMarketContext context;
    internal DbSet<TEntity> dbSet;
    public SQLRepository(HyperMarketContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll() =>
        dbSet;

    public bool SaveAll(IEnumerable<TEntity> entities)        
    {        
        return true;
    }
}
