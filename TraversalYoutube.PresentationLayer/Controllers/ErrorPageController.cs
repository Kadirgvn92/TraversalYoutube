using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class ErrorPageController : Controller
{
    public IActionResult Error404(int code)
    {
        return View();
    }
}
