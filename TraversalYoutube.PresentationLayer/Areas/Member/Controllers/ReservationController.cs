using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;

[Area("Member")]
public class ReservationController : Controller
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IActionResult CurrentReservation()
    {
        return View();
    }
    public IActionResult OldReservation()
    {
        return View();
    }
    [HttpGet]
    public IActionResult NewReservation()
    {
        List<SelectListItem> values = (from x in destinationManager.TGetAll()
                                       select new SelectListItem
                                       {
                                           Text = x.City,
                                           Value = x.DestinationID.ToString()
                                       }).ToList();
        ViewBag.v = values;
        return View();
    }
    [HttpPost]
    public IActionResult NewReservation(Reservation p)
    {
        return View();
    }
}
