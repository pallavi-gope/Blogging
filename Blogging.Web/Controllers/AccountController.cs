using Blogging.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);
            if(identityResult.Succeeded)
            {
                //assign this user a role
                var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");
                if (roleIdentityResult.Succeeded)
                {
                    //show success notification
                    return RedirectToAction("Register");
                }
            }
            //Show error notification
            return View();
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl) {
            var model = new LoginRequest { 
                ReturnUrl = ReturnUrl 
            };
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var signInResult = await signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, false, false);
            if (signInResult != null && signInResult.Succeeded)
            {
                if(!string.IsNullOrWhiteSpace(loginRequest.ReturnUrl))
                {
                    return Redirect(loginRequest.ReturnUrl);
                }
                return RedirectToAction("Index", "Home"); //Action Name , Controller Name
            }
            else
            {
                //show errors
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
