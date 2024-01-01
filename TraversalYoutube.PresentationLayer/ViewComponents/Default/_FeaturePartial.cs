using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _FeaturePartial : ViewComponent
{
    FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
    public IViewComponentResult Invoke()
    {
        var values = featureManager.TGetAll();

        return View(values);
    }
}
