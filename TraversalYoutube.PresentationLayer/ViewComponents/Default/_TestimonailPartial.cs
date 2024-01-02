using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _TestimonailPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
