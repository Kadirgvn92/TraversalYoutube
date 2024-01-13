using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class CityController : Controller
{
    private readonly IDestinationService _destinationService;

    public CityController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CityList()
    {
        var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetAll());
        return Json(jsonCity);
    }
    [HttpPost]
    public IActionResult AddCityDestination(Destination destination)
    {
        destination.Status = true;
        _destinationService.TAdd(destination);
        var values = JsonConvert.SerializeObject(destination);
        return Json(values);
    }

    public IActionResult GetByID(int DestinationID)
    {
        var values = _destinationService.TGetByID(DestinationID);
        var jsonValues = JsonConvert.SerializeObject(values);
        return Json(jsonValues);
    }
    public IActionResult DeleteCity(int id)
    {
        var values = _destinationService.TGetByID(id);
        _destinationService.TDelete(values);
        return NoContent();
    }
    public IActionResult UpdateCity(Destination destination)
    {
        var values = _destinationService.TGetByID(destination.DestinationID);
        _destinationService.TUpdate(values);
        var value2 = JsonConvert.SerializeObject(destination);  
        return Json(value2);
    }
}
