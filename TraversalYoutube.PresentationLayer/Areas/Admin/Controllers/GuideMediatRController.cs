using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.PresentationLayer.CQRS.Commands.GuideCommands;
using TraversalYoutube.PresentationLayer.CQRS.Handlers.GuideHandlers;
using TraversalYoutube.PresentationLayer.CQRS.Queries.GuideQueries;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
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
    [HttpGet]
    public async Task<IActionResult> GetGuides(int id)
    {
        var values = await _mediator.Send(new GetGuideByIDQuery(id));
        return View(values);    
    }
    [HttpGet]
    public IActionResult AddGuide()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddGuide(CreateGuideCommand command)
    {
        await _mediator.Send(command);
        return RedirectToAction("Index", "GuideMediatR", new { area = "Admin" });
    }

    public async Task<IActionResult> DeleteGuide(int id)
    {
        await _mediator.Send(new DeleteGuideCommand(id));
        return RedirectToAction("Index", "GuideMediatR", new { area = "Admin" });
    }
}
