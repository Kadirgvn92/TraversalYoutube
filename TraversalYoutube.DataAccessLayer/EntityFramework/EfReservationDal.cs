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
    public List<Reservation> GetAllReservation(int id)
    {
        using var context = new Context();
        return context.Reservations.Include(x => x.Destination).Where(x => x.AppUserId == id).ToList();
    }

    public List<Reservation> GetListWithReservationByAccepted(int id)
    {
        using var context = new Context();
        return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).Include(x => x.AppUser)
                                   .ToList();
    }

    public List<Reservation> GetListWithReservationByPrevious(int id)
    {
        using var context = new Context();
        return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Tamamlandı" && x.AppUserId == id).Include(x => x.AppUser)
                                   .ToList();
    }

    public List<Reservation> GetListWithReservationByWaitApproval(int id)
    {
        using var context = new Context();  
        return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
    }

    public List<Reservation> GetAll()
    {
        using var context = new Context();
        return context.Reservations.Include(x => x.Destination)
                                   .Include(x => x.AppUser)                        
                                   .ToList();
    }
 }
