using Ecommerce_App.Models;
using Ecommerce_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }

        public AdministrationController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = UserManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $" user with id {id} cannot be found";
                return View("NotFound");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $" user with id {model.Id} cannot be found";
                return View("NotFound");
            }

            else
            {
                user.Email = model.Email;
                user.UserName = model.Username;

                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $" user with id {id} cannot be found";
                return View("NotFound");
            }

            else
            {
                var result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index");
            }
        }
    }
}
