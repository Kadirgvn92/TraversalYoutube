using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Member.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]")]  //burasını loginden sonra redirecttoaction methodu ile ulaşamadıktan sonra ekledik bu route methoduyla member area erişip sayfayı açtık
public class ProfileController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public ProfileController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UserEditViewModel userEditViewModel = new UserEditViewModel();
        userEditViewModel.name = values.Name;
        userEditViewModel.surname = values.Surname;
        userEditViewModel.phonenumber = values.PhoneNumber;
        userEditViewModel.mail = values.Email;
        return View(userEditViewModel);
    }
}
