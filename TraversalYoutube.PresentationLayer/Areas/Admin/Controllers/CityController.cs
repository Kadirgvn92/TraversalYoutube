using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class CityController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CityList()
    {
        var jsonCity = JsonConvert.SerializeObject(cities);
        return Json(jsonCity);
    }

    public static List<City> cities = new List<City>()
    {
        new City
        {
            CityID = 1,
            CityName = "Üsküp",
            CityCountry = "Makedonya"
        },
        new City
        {
            CityID = 2,
            CityName = "Roma",
            CityCountry = "İtalya"
        },
        new City
        {
            CityID = 3,
            CityName = "Londra",
            CityCountry = "İngiltere"
        }
    };
}
