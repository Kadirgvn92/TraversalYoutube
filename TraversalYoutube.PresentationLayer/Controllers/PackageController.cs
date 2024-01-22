using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.Controllers;
[AllowAnonymous]
public class PackageController : Controller
{
    private readonly IDestinationService _destinationService;

    public PackageController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public IActionResult Index()
    {
        var values = _destinationService.TGetAll();
        return View(values);
    }
}
