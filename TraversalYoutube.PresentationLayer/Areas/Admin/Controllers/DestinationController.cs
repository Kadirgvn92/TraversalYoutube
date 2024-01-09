using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
public class DestinationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
