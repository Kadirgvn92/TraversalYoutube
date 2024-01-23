
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Abstract;
public interface IReservationDal :IGenericDal<Reservation>
{
    List<Reservation> GetListWithReservationByWaitApproval(int id);
    List<Reservation> GetListWithReservationByAccepted(int id);
    List<Reservation> GetListWithReservationByPrevious(int id);


    List<Reservation> GetListWithReservationByCancel(int id);
    List<Reservation> GetAllReservation(int id);

    List<Reservation> GetListWithReservationByWaitApproval();
    List<Reservation> GetListWithReservationByAccepted();
    List<Reservation> GetListWithReservationByPrevious();
    List<Reservation> GetListWithReservationByCancel();
} 
