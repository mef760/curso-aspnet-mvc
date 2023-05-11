using MvcCars.Data;

namespace MvcCars.Services;

public class Repository<T> where T: class 
{
    private readonly CarContext _context;

    public Repository(CarContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public T? GetById(int? id)
    {
        if (id == null)
        {
            return null;
        }
        return _context.Set<T>().Find(id);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IEnumerable<T> GetWithFilter(Func<T, bool> query)
    {
        return _context.Set<T>().Where(query).ToList();
    }
}