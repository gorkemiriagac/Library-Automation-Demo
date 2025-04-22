using Library.DataAccess.Context;
using Library.WebUI.Models;
using Library.WebUI.Models.SignModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Library.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Library.WebUI.Helpers;
using Library.WebUI.Dtos.AuthorDtos;

namespace Library.WebUI.Controllers
{
    //  [Route("[area]/[controller]/[action]/{id?}")]
    
    public class HomeController(ILogger<HomeController> logger,UserManager<IdentityConfig> userManager,SignInManager<IdentityConfig> signInManager,LibraryContext _context) : Controller
    {

      
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> SignUp(SignUpViewModels model)
        {
            if (!ModelState.IsValid) return View(model); // Model geçerli deðilse tekrar gönder

            var userCreate = new IdentityConfig()
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };
            var result = await userManager.CreateAsync(userCreate,model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction(nameof(SignIn));

        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async  Task <IActionResult> SignIn(SignInViewModels model)
        {
            if (!ModelState.IsValid) return View(model);

            var hasUser = await userManager.FindByEmailAsync(model.Email);

            if(hasUser is null)
            {
                ModelState.AddModelError(string.Empty, "Email Or Password is wrong");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(hasUser, model.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email Or Password is wrong");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        
        public async Task <IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }

     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
