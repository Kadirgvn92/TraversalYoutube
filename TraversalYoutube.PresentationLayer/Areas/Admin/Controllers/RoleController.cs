using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class RoleController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public RoleController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
    {
        AppRole appRole = new AppRole()
        {
            Name = createRoleViewModel.Rolename
        };

        var result = await _roleManager.CreateAsync(appRole);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Role", new { area = "Admin" });
        }
        else
        {
            return View();
        }
    }
}
