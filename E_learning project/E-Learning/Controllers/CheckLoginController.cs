using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers
{

    public class CheckLoginController : Controller
    {
        [Authorize]
       public IActionResult CheckLogin() { 
        
            List<Claim> claims= User.Claims.ToList();
            Claim claim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            string role = claim.Value;
            if (role == "Student")
            {
                return RedirectToAction("Index", "Courses");   
            }
            else
            {
                return RedirectToAction("Index", "About");

            }

        }
    }
}
