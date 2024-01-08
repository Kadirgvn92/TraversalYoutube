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
public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
{
    public List<Reservation> GetListWithReservationByAccepted(int id)
    {
        throw new NotImplementedException();
    }

    public List<Reservation> GetListWithReservationByPrevious(int id)
    {
        throw new NotImplementedException();
    }

    public List<Reservation> GetListWithReservationByWaitApproval(int id)
    {
        throw new NotImplementedException();
    }
}
