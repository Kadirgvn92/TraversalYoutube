using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.DataAccessLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _StatisticsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        using var context = new Context();
        ViewBag.v = context.Destinations.Count();
        ViewBag.v1 = context.Guides.Count();
        ViewBag.v2 = "254";
        return View();  
    }
}
