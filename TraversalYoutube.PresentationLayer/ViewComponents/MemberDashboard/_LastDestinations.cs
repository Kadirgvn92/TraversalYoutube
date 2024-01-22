using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.ViewComponents.MemberDashboard;

public class _LastDestinations : ViewComponent
{
    private readonly IDestinationService _destinationService;

    public _LastDestinations(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _destinationService.TGetLastFourDestinations();
        return View(values);
    }
}
