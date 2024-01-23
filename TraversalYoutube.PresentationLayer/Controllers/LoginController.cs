using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager; 
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(AppUserRegisterDTO p)
    {
        AppUser appUser = new AppUser()
        {
            Name = p.Name,
            Surname = p.Surname,
            Email = p.Mail,
            UserName = p.Username,
            PhoneNumber = p.PhoneNumber,
            ImageUrl = "default.png"
        };
        if(ModelState.IsValid) 
        {
            var result = await _userManager.CreateAsync(appUser,p.Password);
            if (result.Succeeded) 
            {
                ViewBag.success = "Kayıt başarılı şekilde gerçekleşmiştir.";
                return RedirectToAction("SignIn");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

        }
        return View(p);
    }
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInViewModel p) 
    {
        if(ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "Member"}); 
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz Kullanıcı adı veya Şifre. Lütfen tekrar deneyiniz.";
                return View();
            }
        }
        return View(); 
    }
    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Default");
    }
}
