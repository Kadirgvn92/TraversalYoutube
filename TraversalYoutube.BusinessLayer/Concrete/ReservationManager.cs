using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DataAccessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.Concrete;
public class ReservationManager : IReservationService
{
    private readonly IReservationDal _reservationDal;

    public ReservationManager(IReservationDal reservationDal)
    {
        _reservationDal = reservationDal;
    }

    public List<Reservation> TGetAllReservation(int id)
    {
        return _reservationDal.GetAllReservation(id); 
    }

    public List<Reservation> TGetListWithReservationByAccepted(int id)
    {
        return _reservationDal.GetListWithReservationByAccepted(id);    
    }

    public List<Reservation> TGetListWithReservationByPrevious(int id)
    {
        return _reservationDal.GetListWithReservationByPrevious(id);
    }

    public List<Reservation> TGetListWithReservationByWaitApproval(int id)
    {
       return  _reservationDal.GetListWithReservationByWaitApproval(id);
    }

    public void TAdd(Reservation entity)
    {
        _reservationDal.Insert(entity);
    }

    public void TDelete(Reservation entity)
    {
       _reservationDal.Delete(entity);
    }

    public List<Reservation> TGetAll()
    {
       return _reservationDal.GetAll();
    }

    public Reservation TGetByID(int id)
    {
        return _reservationDal.GetByID(id);
    }

    public void TUpdate(Reservation entity)
    {
        _reservationDal.Update(entity);
    }

    public List<Reservation> TGetListWithReservationByCancel(int id)
    {
        return _reservationDal.GetListWithReservationByCancel(id);
    }

    public List<Reservation> TGetListWithReservationByWaitApproval()
    {
        return _reservationDal.GetListWithReservationByWaitApproval();
    }

    public List<Reservation> TGetListWithReservationByAccepted()
    {
        return _reservationDal.GetListWithReservationByAccepted();
    }

    public List<Reservation> TGetListWithReservationByPrevious()
    {
       return _reservationDal.GetListWithReservationByPrevious();
    }

    public List<Reservation> TGetListWithReservationByCancel()
    {
       return _reservationDal.GetListWithReservationByCancel();
    }
}
