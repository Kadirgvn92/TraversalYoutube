using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.Repository;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.EntityFramework;
public class EfGuideDal : GenericRepository<Guide>, IGuideDal
{
    Context context = new Context();
    public void ChangeToFalseByGuide(int id)
    {
        
        var values = context.Guides.Find(id);
        values.Status = false;
        context.Update(values);
        context.SaveChanges();
    }

    public void ChangeToTrueByGUide(int id)
    {
        var values = context.Guides.Find(id);
        values.Status = true;

        context.Update(values);
        context.SaveChanges();
    }
}
