using Microsoft.EntityFrameworkCore;
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
public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
{
    public Destination GetDestinationWithGuide(int id)
    {
        using var context = new Context();
        return context.Destinations.Where(x => x.DestinationID == id).Include(x => x.Guide).FirstOrDefault();
    }

    public List<Destination> GetLastFourDestinations()
    {
        using var context = new Context();  
        var values = context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
        return values;
    }
}
