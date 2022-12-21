using BL.Interfaces;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BL;

namespace SleepingFight.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBL _userBL;
        private readonly IRegistrationBL _regBL;

        public UserController(IUserBL userBL, IRegistrationBL regBL)
        {
            _userBL = userBL;
            _regBL = regBL;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userBL.GetAll();
            
            return View(users);
        }

        [HttpGet]
        public IActionResult GetUser(string login)
        {
            var user = _userBL.GetUserByLogin(login);
            return View(user);
        }

        [Authorize(Roles = "LeadAdmin")]
        public IActionResult DeleteUser(string login)
        {
            var deleted_user = _userBL.DeleteUser(login);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "LeadAdmin")] 
        public IActionResult AddUser(User user)
        {
            _userBL.AddUser(user);
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration regis)
        {
            var reg = await _regBL.Register(regis);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(reg));

            return RedirectToAction("Play", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login log)
        {
            var loggie =  _regBL.Login(log);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(loggie));

            return RedirectToAction("Play", "Home");
            
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Index");
        }
    }
}
