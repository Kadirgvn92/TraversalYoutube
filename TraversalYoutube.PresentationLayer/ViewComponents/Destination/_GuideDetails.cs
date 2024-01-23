using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Destination;

public class _GuideDetails: ViewComponent
{
    private readonly IGuideService _guideService;

    public _GuideDetails(IGuideService guideService)
    {
        _guideService = guideService;
    }

    public IViewComponentResult Invoke(int id)
    {
        var values = _guideService.TGetByID(id);
        return View(values);
    }
}
