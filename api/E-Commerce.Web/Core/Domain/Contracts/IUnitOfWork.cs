using Domain.Models;

namespace Domain.Contracts;

public interface IUnitOfWork
{
    IGenericRepo<TEntity, TKey> GenericRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    Task<int> SaveChangesAsync();
}