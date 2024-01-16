using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;
using TraversalYoutube.PresentationLayer.CQRS.Queries.DestinationQueries;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
public class DestinationCQRSController : Controller
{
    private readonly GetAllDestinationQueryHandler _handler;
    private readonly GetDestinationByIDQueryHandler _ByIDhandler;

    public DestinationCQRSController(GetAllDestinationQueryHandler handler, GetDestinationByIDQueryHandler byIDhandler)
    {
        _handler = handler;
        _ByIDhandler = byIDhandler;
    }

    public IActionResult Index()
    {
        var values = _handler.Handle();
        return View(values);
    }

    public IActionResult GetDestination(int id)
    {
        var values = _ByIDhandler.Handle(new GetDestinationByIDQuery(id));
        return View(values);    
    }
}
