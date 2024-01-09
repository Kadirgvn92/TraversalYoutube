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

    public List<Reservation> GetAllReservation(int id)
    {
        return _reservationDal.GetAllReservation(id); 
    }

    public List<Reservation> GetListWithReservationByAccepted(int id)
    {
        return _reservationDal.GetListWithReservationByAccepted(id);    
    }

    public List<Reservation> GetListWithReservationByPrevious(int id)
    {
        return _reservationDal.GetListWithReservationByPrevious(id);
    }

    public List<Reservation> GetListWithReservationByWaitApproval(int id)
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
}
