using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;
using TraversalYoutube.PresentationLayer.Areas.Member.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;


[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class DestinationController : Controller
{
    private readonly IDestinationService _destinationService;

    public DestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public IActionResult Index()
    {
        var values = _destinationService.TGetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult AddDestination()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddDestination(Destination destination)
    {
        destination.Image = "/userimages/tour.png";
        destination.Image2 = "/Traversal-Liberty/assets/images/banner1.jpg";
        destination.CoverImage = "/Traversal-Liberty/assets/images/banner4.jpg";

        _destinationService.TAdd(destination);
        return RedirectToAction("Index","Destination", new { area = "Admin"});
    }
    public IActionResult DeleteDestination(int id)
    {
        var values = _destinationService.TGetByID(id);
        _destinationService.TDelete(values);
        return RedirectToAction("Index", "Destination", new { area = "Admin" });
    }
    [HttpGet]
    public IActionResult UpdateDestination(int id)
    {
        var values = _destinationService.TGetByID(id);
        return View(values);
    }
    [HttpPost]
    public IActionResult UpdateDestination(Destination destination)
    {
        _destinationService.TUpdate(destination);
        return RedirectToAction("Index", "Destination", new { area = "Admin" });
    }
}
