using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.ValidationRules;
using TraversalYoutube.EntityLayer.Concrete;
using FluentValidation.Results;

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
        GuideValidator validationRules = new GuideValidator();
        ValidationResult result = validationRules.Validate(guide);
        if (result.IsValid)
        {
            guide.Image = "/userimages/default.png";
            guide.Status = true;
            _guideService.TAdd(guide);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        else
        {
            foreach(var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();  
        
    }

    public IActionResult DeleteGuide(int id)
    {
        var values = _guideService.TGetByID(id);
        _guideService.TDelete(values);
        return RedirectToAction("Index","Guide", new { area = "Admin" });
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
