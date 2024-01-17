using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DataAccessLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.UnitOfWork;
public class UoWDal : IUoWDal
{
    private readonly Context _context;

    public UoWDal(Context context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
