using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Abstract;
public interface IReservationService : IGenericService<Reservation>
{
    List<Reservation> TGetAllReservation(int id);
    List<Reservation> TGetListWithReservationByWaitApproval(int id);
    List<Reservation> TGetListWithReservationByAccepted(int id);
    List<Reservation> TGetListWithReservationByPrevious(int id);

    List<Reservation> TGetListWithReservationByCancel(int id);
    List<Reservation> TGetListWithReservationByWaitApproval();
    List<Reservation> TGetListWithReservationByAccepted();
    List<Reservation> TGetListWithReservationByPrevious();
    List<Reservation> TGetListWithReservationByCancel();
}
