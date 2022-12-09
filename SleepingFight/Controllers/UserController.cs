using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SleepingFight.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UserController( IUserRepo userRepo)
        { 
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var usersList = _userRepo.Select();
            var userOne = _userRepo.Get(2);
            var userL = _userRepo.GetByLogin("vika");
            User userNew = new User()
            {
                Id = 4,
                Login = "Ya",
                Password = "23",
                RegistrationDate = DateTime.Now
            };
            _userRepo.Create(userNew);
            _userRepo.Delete(userNew);
            return View(usersList);
            

        }
    }
}
