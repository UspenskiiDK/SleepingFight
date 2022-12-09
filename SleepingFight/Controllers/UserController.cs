using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return View(usersList);
        }
    }
}
