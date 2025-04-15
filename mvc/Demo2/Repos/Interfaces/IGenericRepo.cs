using System.Linq.Expressions;
using Data.Models;

namespace Repos.Interfaces;

public interface IGenericRepo<TEntity> where TEntity : BaseEntity
{
    TEntity? Getbyid(int id);
    IEnumerable<TEntity> Getall(bool tracking = false);
    IEnumerable<TResult> Getall<TResult>(Expression<Func<TEntity, TResult>> selector);
    int Add(TEntity entity);
    int Update(TEntity entity);
    int Delete(TEntity entity);
    
    // IEnumerable<T> getIEnumerable();
    // IQueryable<T> getIQueryable();
}