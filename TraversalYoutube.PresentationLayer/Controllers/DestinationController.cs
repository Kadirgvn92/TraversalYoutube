using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class DestinationController : Controller
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IActionResult Index()
    {
        var values = destinationManager.TGetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult DestinationDetails(int id)
    {
        return View();  
    }
    [HttpPost]
    public IActionResult DestinationDetails(Destination p)
    {
        return View();
    }
}
