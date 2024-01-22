using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;
[Area("Member")]
public class InformatinController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
