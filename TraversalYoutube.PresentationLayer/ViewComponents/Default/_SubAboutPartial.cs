using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _SubAboutPartial : ViewComponent
{
    SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
    public IViewComponentResult Invoke()
    {
        var values = subAboutManager.TGetAll();
        return View(values);
    }
}
