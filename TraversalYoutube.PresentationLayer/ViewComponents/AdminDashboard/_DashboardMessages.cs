using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;

namespace TraversalYoutube.PresentationLayer.ViewComponents.AdminDashboard;

public class _DashboardMessages : ViewComponent
{
    private readonly IContactUsService _contactUsService;

    public _DashboardMessages(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _contactUsService.TGetAll();
        return View(values);
    }
}
