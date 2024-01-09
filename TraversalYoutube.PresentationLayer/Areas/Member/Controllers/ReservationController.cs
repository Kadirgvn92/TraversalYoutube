using Microsoft.AspNetCore.Identity;
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

    ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

    private readonly UserManager<AppUser> _userManager;

    public ReservationController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> CurrentReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valueList = reservationManager.GetListWithReservationByAccepted(values.Id);
        return View(valueList);
    }
    public async Task<IActionResult> OldReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valueList = reservationManager.GetListWithReservationByPrevious(values.Id);
        return View(valueList);
    }

    public async Task<IActionResult> ApprovalReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valueList = reservationManager.GetListWithReservationByWaitApproval(values.Id);
        return View(valueList);
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
        p.AppUserId = 12;
        p.Status = "Onay Bekliyor";
        reservationManager.TAdd(p);
        return RedirectToAction("CurrentReservation");
    }
}
