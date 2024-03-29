﻿using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.ValidationRules;
using TraversalYoutube.EntityLayer.Concrete;
using FluentValidation.Results;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
[Authorize(Roles = "Admin")]

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
        return RedirectToAction("Index", "Guide", new { area = "Admin" });
    }
    public IActionResult ChangeToTrue(int id)
    {
        _guideService.TChangeToTrueByGUide(id);
        return RedirectToAction("Index","Guide", new { area = "Admin" } );
    }
    public IActionResult ChangeToFalse(int id)
    {
        _guideService.TChangeToFalseByGuide(id);
        return RedirectToAction("Index", "Guide", new { area = "Admin" });
    }

}
