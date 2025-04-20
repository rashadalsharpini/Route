using System.Linq.Expressions;
using Data.Contexts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repos.Interfaces;

namespace Repos.Repos;

public class GenericRepo<T>(AppDbContext db): IGenericRepo<T> where T : BaseEntity
{
    public T? Getbyid(int id) =>
        db.Set<T>().Find(id);
    
    public IEnumerable<T> Getall(bool tracking = false)=>
        tracking ? db.Set<T>().ToList() : db.Set<T>().AsNoTracking().Where(e=>e.IsDeleted!=true).ToList();
    
    public IEnumerable<TResult> Getall<TResult>(Expression<Func<T, TResult>> selector)
    {
        return db.Set<T>().Where(e=>e.IsDeleted!=true).Select(selector).ToList();
    }

    public IEnumerable<T> Getall(Expression<Func<T, bool>> predicate)
    {
       return db.Set<T>().Where(e=>e.IsDeleted!=true).Where(predicate).ToList(); 
    }

    public void Add(T entity)
    {
        db.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        db.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        db.Set<T>().Remove(entity);
    }

    // public IEnumerable<T> getIEnumerable()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public IQueryable<T> getIQueryable()
    // {
    //     throw new NotImplementedException();
    // }
}