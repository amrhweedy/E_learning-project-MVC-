using E_Learning.viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace E_Learning.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _RoleManager)
        {
            roleManager = _RoleManager;
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleVM)
        {
            if (ModelState.IsValid) 
            {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleVM.RoleName;
                
                IdentityResult result = await roleManager.CreateAsync(roleModel);
                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("RoleName", item.Description);
                        

                    }
                }
            }
            return View(roleVM);
        }
    }
}

