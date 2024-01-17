using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
