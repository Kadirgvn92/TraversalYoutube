using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.AdminDashboard;

public class _DashboardBanner :ViewComponent
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
    public IViewComponentResult Invoke()
    {
        var values = reservationManager.TGetAll().ToList();
        return View(values);
    }
}
