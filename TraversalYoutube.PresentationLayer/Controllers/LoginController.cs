﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    //[HttpPost]
    //public IActionResult SignUp()
    //{
    //    return View();
    //}
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
}
