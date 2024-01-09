using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.MemberDashboard;

public class _GuideList :ViewComponent
{
    GuideManager guideManager = new GuideManager(new EfGuideDal());
    public IViewComponentResult Invoke()
    {
        var values = guideManager.TGetAll();

        return View(values);
    }
}
