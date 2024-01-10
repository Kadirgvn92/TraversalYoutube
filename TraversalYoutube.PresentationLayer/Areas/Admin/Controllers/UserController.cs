using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    private readonly IAppUserService _appUserService;

    public UserController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
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
        return RedirectToAction("Index","Dashboard");
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
        return RedirectToAction("Index");
    }
    
    public IActionResult CommentUser(int id)
    {
        _appUserService.TGetAll();
        return View();
    }
}
