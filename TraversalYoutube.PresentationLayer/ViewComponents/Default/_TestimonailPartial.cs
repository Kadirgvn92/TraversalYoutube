using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _TestimonailPartial : ViewComponent
{
    TestimonailManager testimonailManager = new TestimonailManager(new EfTestimonailDal());
    public IViewComponentResult Invoke()
    {
        var values = testimonailManager.TGetAll();
        return View(values);
    }
}
