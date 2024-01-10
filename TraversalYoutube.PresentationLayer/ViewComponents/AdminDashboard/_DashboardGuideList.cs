using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.AdminDashboard;

public class _DashboardGuideList :ViewComponent
{
    GuideManager guideManager = new GuideManager(new EfGuideDal());
    public IViewComponentResult Invoke()
    {
        var values = guideManager.TGetAll();
        return View(values);  
    }
}
