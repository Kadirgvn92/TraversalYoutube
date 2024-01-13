using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
public class ContactUsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
