using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class ContactController : Controller
{
    private readonly IContactUsService contactUsService;

    public ContactController(IContactUsService contactUsService)
    {
        this.contactUsService = contactUsService;
    }

    public IActionResult Index()
    {
        var values = contactUsService.TGetAll();
        return View(values);
    }
}
