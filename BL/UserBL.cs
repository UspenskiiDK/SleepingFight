using BL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BL
{
    public class UserBL : IUserBL
    {
        private readonly IMainRepo<User> _userRepo;

        public UserBL(IMainRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task AddUser(User user)
        {
            var n_user = new User()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RegistrationDate = DateTime.Now,
                Status = "Unknown"
            };

            await _userRepo.Create(n_user);

        }

        public async Task DeleteUser(string login)
        {
            var user = await _userRepo.GetByLogin(login);
            await _userRepo.Delete(user);

        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepo.Select();
            return users;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _userRepo.GetByLogin(login);
            
        }
    }
}
