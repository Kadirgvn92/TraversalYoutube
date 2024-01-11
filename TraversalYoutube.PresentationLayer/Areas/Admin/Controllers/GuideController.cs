using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class GuideController : Controller
{
    private readonly IGuideService _guideService;

    public GuideController(IGuideService guideService)
    {
        _guideService = guideService;
    }

    public IActionResult Index()
    {
        var values = _guideService.TGetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult AddGuide()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddGuide(Guide guide) 
    { 
        _guideService.TAdd(guide);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult EditGuide(int id)
    {
        var values = _guideService.TGetByID(id);
        return View(values);
    }
    [HttpPost]
    public IActionResult EditGuide(Guide guide)
    {
        _guideService.TUpdate(guide);
        return RedirectToAction("Index");   
    }
    public IActionResult ChangeStatus(int id)
    {

        return RedirectToAction("Index");   
    }

}
