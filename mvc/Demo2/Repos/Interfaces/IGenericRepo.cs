using System.Linq.Expressions;
using Data.Models;

namespace Repos.Interfaces;

public interface IGenericRepo<TEntity> where TEntity : BaseEntity
{
    TEntity? Getbyid(int id);
    IEnumerable<TEntity> Getall(bool tracking = false);
    IEnumerable<TResult> Getall<TResult>(Expression<Func<TEntity, TResult>> selector);
    IEnumerable<TEntity> Getall(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    
    // IEnumerable<T> getIEnumerable();
    // IQueryable<T> getIQueryable();
}