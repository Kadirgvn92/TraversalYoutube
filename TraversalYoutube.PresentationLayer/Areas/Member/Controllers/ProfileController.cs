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
        userEditViewModel.imageurl = values.ImageUrl;
        return View(userEditViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);


        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(userEditViewModel.Image.FileName);
        var imagename = Guid.NewGuid() + extension;
        var savelocation = resource + "/wwwroot/userimages/" + imagename;
        var stream = new FileStream(savelocation, FileMode.Create);
        await userEditViewModel.Image.CopyToAsync(stream);
        user.ImageUrl = imagename;


        user.Name = userEditViewModel.name;
        user.Surname = userEditViewModel.surname;
        user.PhoneNumber = userEditViewModel.phonenumber;
        user.Email = userEditViewModel.mail;
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.password);
        if (userEditViewModel.password == userEditViewModel.confirmpassword)
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "Member" });
            }
            else
            {
                return RedirectToAction("Index", "Profile", new { area = "Member" });
            }
        }

        return View();
    }
}
