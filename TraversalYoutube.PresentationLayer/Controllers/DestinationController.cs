using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class DestinationController : Controller
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IActionResult Index()
    {
        var values = destinationManager.TGetAll();
        return View(values);
    }
}
