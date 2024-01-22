using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class DestinationManager : IDestinationService
{
    private readonly IDestinationDal _destinationDal;

    public DestinationManager(IDestinationDal destinationDal)
    {
        _destinationDal = destinationDal;
    }

    public void TAdd(Destination entity)
    {
       _destinationDal.Insert(entity);
    }

    public void TDelete(Destination entity)
    {
       _destinationDal.Delete(entity);
    }

    public List<Destination> TGetAll()
    {
        return _destinationDal.GetAll();
    }

    public Destination TGetByID(int id)
    {
        return _destinationDal.GetByID(id);
    }

    public Destination TGetDestinationWithGuide(int id)
    {
        return _destinationDal.GetDestinationWithGuide(id);
    }

    public List<Destination> TGetLastFourDestinations()
    {
        return _destinationDal.GetLastFourDestinations();
    }

    public void TUpdate(Destination entity)
    {
        _destinationDal.Update(entity);
    }
}
