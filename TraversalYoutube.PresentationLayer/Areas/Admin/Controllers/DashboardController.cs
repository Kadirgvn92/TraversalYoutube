using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class DashboardController : Controller
{
    private readonly IDestinationService _destinationService;
    private readonly IReservationService _reservationService;
    Context context = new Context();

    public DashboardController(IDestinationService destinationService, IReservationService reservationService)
    {
        _destinationService = destinationService;
        _reservationService = reservationService;
    }

    public IActionResult Index()
    {
        ViewBag.v1 = _destinationService.TGetAll().Count();
        ViewBag.v2 = context.Comments.Count();  
        ViewBag.v3 = context.Users.Count();
        ViewBag.v4 = _reservationService.TGetListWithReservationByWaitApproval().Count();
        return View();
    }
}
