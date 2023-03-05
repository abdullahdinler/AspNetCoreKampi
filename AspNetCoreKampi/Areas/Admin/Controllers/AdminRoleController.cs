using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.ViewModels;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreKampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roleList = _roleManager.Roles.ToList();
            return View(roleList);
        }

        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            return View(userList);
        }


        [HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new AppRole()
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RoleUpdate(int id)
        {
            var appRole = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (appRole!=null)
            {
                AppRoleUpdateViewModel appRoleUpdate = new AppRoleUpdateViewModel()
                {
                    Id = appRole.Id,
                    Name = appRole.Name
                };
                return View(appRoleUpdate);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(AppRoleUpdateViewModel model)
        {
            var appRole = await _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (appRole != null )
            {
                appRole.Name = model.Name;
                var result = await _roleManager.UpdateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("" , error.Description);
                    }
                }
                
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleDelete(int id)
        {
            var appRole = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (appRole != null)
            {
                var result = await _roleManager.DeleteAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var roles = await _roleManager.Roles.ToListAsync();
            TempData["userId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleViewModel> models = new();
            foreach (var role in roles)
            {
                AssignRoleViewModel model = new();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                model.Exists = userRoles.Contains(role.Name);
                models.Add(model);

            }

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> model)
        {
            var userId = (int) TempData["userId"];
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }

    }
}
