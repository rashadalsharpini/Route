using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.Data;

namespace Persistence.Repos;

public class UnitOfWork(StoreDbContext db) : IUnitOfWork
{
    private readonly Dictionary<string, object> _mpRepos = [];

    public IGenericRepo<TEntity, TKey> GenericRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        // if (mpRepos.ContainsKey(typeName))
        //     return (IGenericRepo<TEntity, TKey>)mpRepos[typeName];
        if (_mpRepos.TryGetValue(typeName, out object? value))
            return (IGenericRepo<TEntity, TKey>)value;
        var repo = new GenericRepo<TEntity, TKey>(db);
        // _mpRepos.Add(typeName, repo);
        _mpRepos[typeName] = repo;
        return repo;
    }

    public async Task<int> SaveChangesAsync() => await db.SaveChangesAsync();
}