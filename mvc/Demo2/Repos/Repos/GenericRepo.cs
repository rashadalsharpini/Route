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

    public int Add(T entity)
    {
        db.Set<T>().Add(entity);
        return db.SaveChanges();
    }

    public int Update(T entity)
    {
        db.Set<T>().Update(entity);
        return db.SaveChanges();
    }

    public int Delete(T entity)
    {
        db.Set<T>().Remove(entity);
        return db.SaveChanges();
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