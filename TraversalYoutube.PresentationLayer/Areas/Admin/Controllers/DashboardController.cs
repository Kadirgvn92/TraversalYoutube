using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    Context context = new Context();
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
    public IActionResult Index()
    {
        ViewBag.v1 = context.Destinations.Count();
        ViewBag.v2 = context.Comments.Count();  
        ViewBag.v3 = context.Users.Count();
        ViewBag.v4 = context.Reservations.Count();
        return View();
    }
}
