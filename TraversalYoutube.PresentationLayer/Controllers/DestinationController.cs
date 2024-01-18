using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Controllers;
[AllowAnonymous]
public class DestinationController : Controller
{
    DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    private readonly UserManager<AppUser> _userManager;

    public DestinationController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var values = destinationManager.TGetAll();
        return View(values);
    }
    public async Task<IActionResult> DestinationDetails(int id)
    {
        ViewBag.i = id;
        var values2 = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.user = values2.Id;
        var values = destinationManager.TGetDestinationWithGuide(id);
        return View(values);  
    }
}
