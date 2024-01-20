using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.SignalRApi.Model;

namespace TraversalYoutube.SignalRApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VisitorController : ControllerBase
{
    private readonly VisitorService _visitorService;

    public VisitorController(VisitorService visitorService)
    {
        _visitorService = visitorService;
    }
}
