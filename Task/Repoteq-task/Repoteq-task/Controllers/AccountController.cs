using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repoteq_task.ViewModel;

namespace Repoteq_task.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterAccountViewModel newAccount)
        {
            if (ModelState.IsValid == true)
            {
                //map from vm to model
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.Username;
                user.Email = newAccount.Email;

                //save user and create cookie
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                    
                

            }
            return View(newAccount);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if(ModelState.IsValid == true)
            {
                IdentityUser user = await userManager.FindByIdAsync(loginUser.UserName);
                if (user != null) {
                    Microsoft.AspNetCore.Identity.SignInResult result = 
                        await signInManager.PasswordSignInAsync(user, loginUser.Password , loginUser.isPersisite , false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "incorrect username or password");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "invalid username or password");
                }
            }
            return View(loginUser);
        }
    }
}
