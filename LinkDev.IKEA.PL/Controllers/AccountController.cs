using LinkDev.IKEA.DAL.Entities.Identity;
using LinkDev.IKEA.PL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class AccountController : Controller
    {
         private readonly UserManager<ApplicationUser> _userManager;

         public AccountController(UserManager<ApplicationUser> userManager)
         {
            _userManager = userManager;
         }
        #region Sign UP 

        [HttpGet]
         public IActionResult SignUp()
         {
             return View();
         }

        [HttpPost]
         public async Task<IActionResult> SignUp(SignUpViewModel model)
         {
             if (!ModelState.IsValid)
                 return View(model);
             var user = await _userManager.FindByNameAsync(model.UserName);

             if(user is not null)
             {
                 ModelState.AddModelError("UserName", "This User Name is Already Taken");
                 return View(model);
             }
            user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                IsAgree = model.IsAgree

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return RedirectToAction(nameof(SignIn));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
                

         }
        #endregion

        #region SignIn
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        #endregion
    }
    }

