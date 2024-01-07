using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
