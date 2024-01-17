using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

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
    public async Task<IActionResult> AddDestination(CreateDestinationViewModel destination)
    {
        if (destination.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(destination.Image.FileName);
            var imagename = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/destinationimages/" + imagename;
            var stream = new FileStream(savelocation, FileMode.Create);
            await destination.Image.CopyToAsync(stream);
            destination.imageurl = imagename;
        }
        destination.Image2 = "/Traversal-Liberty/assets/images/banner1.jpg";
        destination.CoverImage = "/Traversal-Liberty/assets/images/banner4.jpg";

        Destination des = new Destination()
        {
            City = destination.City,
            DayNight = destination.DayNight,
            Price = destination.Price,
            Capacity = destination.Capacity,
            Description = destination.Description,
            Status = true,
            Details1 = destination.Details1,
            Details2 = destination.Details2,
            Image2 = "/Traversal-Liberty/assets/images/banner1.jpg",
            CoverImage = "/Traversal-Liberty/assets/images/banner4.jpg",
            Image = destination.imageurl
        };

        _destinationService.TAdd(des);
        return RedirectToAction("Index", "Destination", new { area = "Admin" });
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
    public async Task<IActionResult> UpdateDestination(UpdateDestinationViewModel destination)
    {
        if (destination.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(destination.Image.FileName);
            var imagename = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/destinationimages/" + imagename;
            var stream = new FileStream(savelocation, FileMode.Create);
            await destination.Image.CopyToAsync(stream);
            destination.imageurl = imagename;
        }


        Destination des = new Destination()
        {
            DestinationID = destination.DestinationID,
            City = destination.City,
            DayNight = destination.DayNight,
            Price = destination.Price,
            Capacity = destination.Capacity,
            Description = destination.Description,
            Status = true,
            Details1 = destination.Details1,
            Details2 = destination.Details2,
            Image2 = "/Traversal-Liberty/assets/images/banner1.jpg",
            CoverImage = "/Traversal-Liberty/assets/images/banner4.jpg",
            Image = destination.imageurl
        };
        _destinationService.TUpdate(des);
        return RedirectToAction("Index", "Destination", new { area = "Admin" });
    }
}
