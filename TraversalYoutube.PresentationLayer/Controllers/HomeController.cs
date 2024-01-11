using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Index sayfası çağırıldı");
        return View();
    }

    public IActionResult Privacy()
    {
        _logger.LogInformation($"Login sayfası çağırıldı");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
