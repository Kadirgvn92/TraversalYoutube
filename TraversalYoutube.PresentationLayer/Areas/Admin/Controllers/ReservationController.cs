using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public IActionResult Index()
    {
        var values = _reservationService.TGetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult AcceptedReservation()
    {
        var values = _reservationService.TGetListWithReservationByAccepted();
        return View(values);
    }
    [HttpGet]
    public IActionResult OldReservation()
    {
        var values = _reservationService.TGetListWithReservationByPrevious();
        return View(values);
    }
    [HttpGet]
    public IActionResult CanceledReservation()
    {
        var values = _reservationService.TGetListWithReservationByCancel();
        return View(values);
    }
    [HttpGet]
    public IActionResult ApprovalReservation()
    {
        var values = _reservationService.TGetListWithReservationByWaitApproval();
        return View(values);
    }
}
