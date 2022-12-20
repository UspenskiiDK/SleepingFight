using BL.Interfaces;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SleepingFight.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
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
    }
}
