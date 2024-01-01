using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _DestinationPartial :ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();  
    }
}
