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
    private readonly UserManager<AppUser> _userManager;

    public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
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
    [HttpGet]  
    public async Task<IActionResult> AssignRole(int id)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
        TempData["userid"] = user.Id;
        var roles = _roleManager.Roles.ToList();
        var userRoles = await _userManager.GetRolesAsync(user);
        List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
        foreach (var item in roles)
        {
            RoleAssignViewModel model = new RoleAssignViewModel();
            model.RoleID = item.Id;
            model.RoleExist = userRoles.Contains(item.Name);
            model.RoleName = item.Name;
            roleAssignViewModels.Add(model);
        }
        return View(roleAssignViewModels);
    }
    [HttpPost]
    public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
    {
        var userID = (int)TempData["userid"];
        var user = _userManager.Users.FirstOrDefault(x => x.Id == userID);
        foreach (var item in model)
        {
            if(item.RoleExist)
            {
                await _userManager.AddToRoleAsync(user, item.RoleName);

            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, item.RoleName);
            }
        }
        return RedirectToAction("Index", "User", new { area = "Admin" });
    }
}
