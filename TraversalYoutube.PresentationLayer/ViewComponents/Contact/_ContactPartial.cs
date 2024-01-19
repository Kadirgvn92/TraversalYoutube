using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Contact;

public class _ContactPartial : ViewComponent
{
    private readonly IContactService _contactService;

    public _ContactPartial(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _contactService.TGetAll();
        return View(values); 
    }  

}
