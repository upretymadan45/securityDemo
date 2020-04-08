using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sqlinj.Models;
using sqlinj.Repository;

namespace sqlinj.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View(new AppUser());
        }

        [HttpPost]
        public IActionResult Login(AppUser user)
        {
            if(!ModelState.IsValid)
                return View(user);

            var isValidUser = userRepository.AuthenticateUser(user);

            if (isValidUser)
            {
                HttpContext.Session.SetString("isLoggedIn", "true");

                HttpContext.Session.SetString("UserName",user.UserName);

                SetMessage("Logged in successfully..", "success");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.Session.SetString("isLoggedIn", "false");
                SetMessage("Could not logged in. Please try again..", "error");
                return RedirectToAction(nameof(Login));
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            SetMessage("Logged out successfully","success");

            return RedirectToAction(nameof(Login));
        }
    }
}