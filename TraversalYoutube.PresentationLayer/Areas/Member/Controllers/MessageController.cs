using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;
public class MessageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
