using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
public class MessageController : Controller
{
    private readonly IContactUsService _contactUsService;

    public MessageController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    public IActionResult Index()
    {
        var values = _contactUsService.TGetAll();
        return View(values);
    }
}
