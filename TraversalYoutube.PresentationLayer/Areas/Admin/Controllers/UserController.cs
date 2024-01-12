﻿using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]

[Route("Admin/[controller]/[action]/{id?}")]
public class UserController : Controller
{
    private readonly IAppUserService _appUserService;
    private readonly IReservationService _reservationService;

    public UserController(IAppUserService appUserService, IReservationService reservationService)
    {
        _appUserService = appUserService;
        _reservationService = reservationService;
    }

    public IActionResult Index()
    {
        var values = _appUserService.TGetAll();
        return View(values);
    }
    public IActionResult DeleteUser(int id)
    {
        var values = _appUserService.TGetByID(id);
        _appUserService.TDelete(values);
        return RedirectToAction("Index","Dashboard",new { area = "Admin" });
    }
    [HttpGet]
    public IActionResult EditUser(int id)
    {
        var values = _appUserService.TGetByID(id);
        _appUserService.TUpdate(values);
        return View(values);
    }
    [HttpPost]
    public IActionResult EditUser(AppUser appUser)
    {
        _appUserService.TUpdate(appUser);
        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
    }
    
    public IActionResult CommentUser(int id)
    {
        _appUserService.TGetAll();
        return View();
    }
    public IActionResult ReservationUser(int id)
    {
        var values = _reservationService.GetListWithReservationByPrevious(id);
        return View(values);
    }
}
