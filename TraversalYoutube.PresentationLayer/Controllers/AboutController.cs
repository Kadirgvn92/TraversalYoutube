using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
