using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Repository;
public class GenericUoWRepository<T> : IGenericUoWDal<T> where T : class
{
    private readonly Context _context;

    public GenericUoWRepository(Context context)
    {
        _context = context;
    }

    public T GetByID(int id)
    {
        return _context.Set<T>().Find(id); 
    }

    public void Insert(T item)
    {
        _context.Add(item);
    }

    public void MultiUpdate(List<T> items)
    {
        _context.UpdateRange(items);
    }

    public void Update(T item)
    {
        _context.Update(item);
    }
}
