using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.BusinessLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _PopularDestinationsPartial :ViewComponent
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IViewComponentResult Invoke()
    {
        var values = destinationManager.TGetAll();
        return View(values);  
    }
}
