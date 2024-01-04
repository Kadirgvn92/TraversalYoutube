using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Repository;
public class GenericRepository<T> : IGenericDal<T> where T : class
{
    
    public void Delete(T t)
    {
       using var context = new Context();
       context.Remove(t);
        context.SaveChanges();
    }

    public List<T> GetAll()
    {
        using var context = new Context();  

        return context.Set<T>().ToList();
    }

    public T GetByID(int id)
    {
        using var context = new Context();
        return context.Set<T>().Find(id);
    }
    public void Insert(T t)
    {
        using var context = new Context();
        context.Add(t);
        context.SaveChanges();
    }

    public void Update(T t)
    {
        var context = new Context();
        context.Update(t);
        context.SaveChanges();
    }
}
