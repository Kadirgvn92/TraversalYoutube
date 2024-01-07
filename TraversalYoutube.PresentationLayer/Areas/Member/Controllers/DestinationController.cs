using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;

[Area("Member")]
[AllowAnonymous]
public class DestinationController : Controller
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

    public IActionResult Index()
    {
        var values = destinationManager.TGetAll();
        return View(values);
    }
}
