using ConsoleApp1.DbContexts;

namespace ConsoleApp1;
// i don't know if this class is good practise or not
// it's just and idea i had
public class CRUDOperations<T> where T : class
{
    public void Add(ITIDbContext db, T entity)
    {
        db.Add(entity);
        db.SaveChanges();
    }

    public T? GetById(ITIDbContext db, int id)
    {
        return db.Find<T>(id);
    }

    public void Update(ITIDbContext db, T entity)
    {
        db.Update(entity);
        db.SaveChanges();
    }

    public void Delete(ITIDbContext db, T? entity)
    {
        var entityToDelete = db.Find<T>(entity);
        if (entityToDelete is not null)
        {
            db.Remove(entityToDelete);
            db.SaveChanges();
        }
    }
}