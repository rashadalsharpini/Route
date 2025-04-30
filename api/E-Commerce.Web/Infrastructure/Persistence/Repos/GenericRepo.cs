using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repos;

public class GenericRepo<TEntity, TKey>(StoreDbContext db):IGenericRepo<TEntity, TKey> where TEntity:BaseEntity<TKey>
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await db.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await db.Set<TEntity>().FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await db.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        db.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        db.Set<TEntity>().Remove(entity);
    }
}