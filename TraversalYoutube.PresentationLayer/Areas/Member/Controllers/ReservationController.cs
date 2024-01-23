using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.DTOLayer.DTOs.ReservaitonDTOs;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]
public class ReservationController : Controller
{
    private readonly IDestinationService _destinationService;   
    private readonly IReservationService _reservationService;   
    private readonly UserManager<AppUser> _userManager;

    public ReservationController(IDestinationService destinationService, IReservationService reservationService, UserManager<AppUser> userManager)
    {
        _destinationService = destinationService;
        _reservationService = reservationService;
        _userManager = userManager;
    }

    public async Task<IActionResult> CurrentReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valueList = _reservationService.TGetListWithReservationByAccepted(values.Id);
        return View(valueList);
    }
    public async Task<IActionResult> OldReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valueList = _reservationService.TGetListWithReservationByPrevious(values.Id);
        return View(valueList);
    }

    public async Task<IActionResult> ApprovalReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valueList = _reservationService.TGetListWithReservationByWaitApproval(values.Id);
        return View(valueList);
    }
    [HttpGet]
    public IActionResult NewReservation()
    {
        List<SelectListItem> values = (from x in _destinationService.TGetAll()
                                       select new SelectListItem
                                       {
                                           Text = x.City,
                                           Value = x.DestinationID.ToString()
                                       }).ToList();
        ViewBag.v = values;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> NewReservation(Reservation model)
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        model.AppUserId = values.Id;
        model.Status = "Onay Bekliyor";

        _reservationService.TAdd(model);
        return RedirectToAction("ApprovalReservation","Reservation",new { area = "Member" });
    }
}
