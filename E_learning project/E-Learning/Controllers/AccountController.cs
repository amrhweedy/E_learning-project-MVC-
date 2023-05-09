using E_Learning.Interface;
using E_Learning.Models;
using E_Learning.Repository;
using E_Learning.viewmodel;
using E_Learning_Platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace E_Learning.Controllers
{
    public class AccountController : Controller

    {
        private readonly UserManager<App_user> userManager;
        private readonly SignInManager<App_user> signInManager;
        IGenericRepository<Student> studentRepository;

        public AccountController(UserManager<App_user> userManager ,SignInManager<App_user> signInManager, IGenericRepository<Student> studentRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            studentRepository = studentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterViewModel registerViewModel)

        {
            if (ModelState.IsValid)
            {

                App_user applicationuser = new App_user();
                applicationuser.UserName = registerViewModel.UserName;
                applicationuser.PasswordHash= registerViewModel.Password;
                applicationuser.Email = registerViewModel.Email;



                IdentityResult result = await userManager.CreateAsync(applicationuser, registerViewModel.Password);
                //IdentityResult result = await userManager.CreateAsync(applicationuser);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationuser,"Student");
                    await signInManager.SignInAsync(applicationuser, false);
                    Student newStudent = new Student();
                    newStudent.User_id = applicationuser.Id;
                    newStudent.Profile_Picture = "profile.jpg";
                    studentRepository.Insert(newStudent);
                    return RedirectToAction("Index", "Courses"); 

                }
                else
                {
                    foreach (var item in result.Errors)

                    { ModelState.AddModelError("", item.Description); }

                }

            }
            return View(registerViewModel);

        }

        ////instructor
        //public IActionResult InstructorRegister()
        //{

        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InstructorRegister(RegisterViewModel registerViewModel)

        //{
        //    if (ModelState.IsValid)
        //    {

        //        App_user applicationuser = new App_user();
        //        applicationuser.UserName = registerViewModel.UserName;
        //        applicationuser.PasswordHash = registerViewModel.Password;
        //        applicationuser.Email = registerViewModel.Email;



        //        IdentityResult result = await userManager.CreateAsync(applicationuser, registerViewModel.Password);
        //        //IdentityResult result = await userManager.CreateAsync(applicationuser);
        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(applicationuser, "Instructor");
        //            await signInManager.SignInAsync(applicationuser, false);
        //            return RedirectToAction("Index", "About");
        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)

        //            { ModelState.AddModelError("", item.Description); }

        //        }

        //    }
        //    return View(registerViewModel);

        //}






        //login 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                App_user applicationUser = await userManager.FindByNameAsync(loginViewModel.UserName);
                if (applicationUser != null)
                {
                    await signInManager.PasswordSignInAsync(applicationUser, loginViewModel.Password, loginViewModel.RememberMe, false);

                    return RedirectToAction("CheckLogin", "CheckLogin");
                


                }
                else
                {
                    ModelState.AddModelError("", "username or password is wrong");
                }
            }
            return View(loginViewModel);
        }


        //logout
        public ActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }






    }
    }

