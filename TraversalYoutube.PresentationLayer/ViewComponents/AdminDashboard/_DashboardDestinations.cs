using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.AdminDashboard;

public class _DashboardDestinations : ViewComponent
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IViewComponentResult Invoke()
    {
        var values = destinationManager.TGetAll();
        return View(values);  
    }
}
