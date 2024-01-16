using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.PresentationLayer.CQRS.Queries.GuideQueries;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
public class GuideMediatRController : Controller
{
    private readonly IMediator _mediator;

    public GuideMediatRController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _mediator.Send(new GetAllGuideQuery());
        return View(values);
    }
}
