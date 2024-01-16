using iTextSharp.text.xml.simpleparser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.PresentationLayer.CQRS.Commands.DestinationCommands;
using TraversalYoutube.PresentationLayer.CQRS.Handlers.DestinationHandlers;
using TraversalYoutube.PresentationLayer.CQRS.Queries.DestinationQueries;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class DestinationCQRSController : Controller
{
    private readonly GetAllDestinationQueryHandler _handler;
    private readonly GetDestinationByIDQueryHandler _getByIDHandler;
    private readonly CreateDestinationCommandHandler _createCommand;
    private readonly DeleteDestinationCommandHandler _deleteCommand;
    private readonly UpdateDestinationCommandHandler _updateCommand;

    public DestinationCQRSController(GetAllDestinationQueryHandler handler, 
        GetDestinationByIDQueryHandler getByIDHandler, 
        CreateDestinationCommandHandler createCommand, 
        DeleteDestinationCommandHandler deleteCommand, 
        UpdateDestinationCommandHandler updateCommand)
    {
        _handler = handler;
        _getByIDHandler = getByIDHandler;
        _createCommand = createCommand;
        _deleteCommand = deleteCommand;
        _updateCommand = updateCommand;
    }

    public IActionResult Index()
    {
        var values = _handler.Handle();
        return View(values);
    }

    [HttpGet]
    public IActionResult GetDestination(int id)
    {
        var values = _getByIDHandler.Handle(new GetDestinationByIDQuery(id));
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateDestination()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateDestination(CreateDestinationCommand command)
    {
        _createCommand.Handle(command);
        return RedirectToAction("Index", "DestinationCQRS", new { area = "Admin" });
    }

    public IActionResult DeleteDestination(int id)
    {
        _deleteCommand.Handle(new DeleteDestinationCommand(id));
        return RedirectToAction("Index", "DestinationCQRS", new { area = "Admin" });
    }

    [HttpPost]
    public IActionResult GetDestination(UpdateDestinationCommand command)
    {
        _updateCommand.Handle(command);
        return RedirectToAction("Index", "DestinationCQRS", new { area = "Admin" });
    }

}
