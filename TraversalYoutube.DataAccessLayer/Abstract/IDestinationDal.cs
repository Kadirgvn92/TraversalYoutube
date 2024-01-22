using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Abstract;
public interface IDestinationDal : IGenericDal<Destination>
{
    public Destination GetDestinationWithGuide(int id);
    public List<Destination> GetLastFourDestinations ();
}
