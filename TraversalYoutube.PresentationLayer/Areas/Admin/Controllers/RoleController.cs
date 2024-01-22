using DocumentFormat.OpenXml.Office2010.Excel;
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

    public async Task<IActionResult> DeleteRole(int id)
    {
        var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        await _roleManager.DeleteAsync(value);
        return RedirectToAction("Index", "Role", new { area = "Admin" });
    }
    [HttpGet]
    public IActionResult UpdateRole(int id)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        UpdateRoleViewModel updateDestinationViewModel = new UpdateRoleViewModel()
        {
            RoleID = values.Id,
            RoleName = values.Name
        };
        return View(updateDestinationViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
        values.Name = updateRoleViewModel.RoleName;
        await _roleManager.UpdateAsync(values);
        return RedirectToAction("Index", "Role", new { area = "Admin" });
    }

}
