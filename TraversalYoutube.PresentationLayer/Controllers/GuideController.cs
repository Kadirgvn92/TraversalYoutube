using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.Controllers;
[AllowAnonymous]
public class GuideController : Controller
{
    private readonly IGuideService _guideService;

    public GuideController(IGuideService guideService)
    {
        _guideService = guideService;
    }

    public IActionResult Index()
    {
        var values = _guideService.TGetAll();
        return View(values);
    }
}
