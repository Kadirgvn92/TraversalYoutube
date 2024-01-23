using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;
public class CommentController : Controller
{
    [Area("Member")]
    public IActionResult Index()
    {
        return View();
    }
}
