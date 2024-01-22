using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]
public class DestinationController : Controller
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

    public IActionResult Index(string searchString)
    {
        ViewData["CurrentFilter"] = searchString;
        var valueSeach = from x in destinationManager.TGetAll() select x;
        if (!string.IsNullOrEmpty(searchString))
        {
            valueSeach = valueSeach.Where(y => y.City.Contains(searchString));
        }
        return View(valueSeach.ToList());
    }
}
