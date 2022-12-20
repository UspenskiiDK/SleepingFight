using BL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;

namespace BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepo _userRepo;

        public UserBL(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public bool AddUser(User user)
        {
            var n_user = new User()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RegistrationDate = DateTime.Now
            };

            _userRepo.Create(n_user);
            if (n_user == null) return false;
            return true;
        }

        public bool DeleteUser(string login)
        {
            var user = _userRepo.GetByLogin(login);
            if (user == null) return false;

            _userRepo.Delete(user);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepo.Select();
            return users;
        }

        public User GetUserByLogin(string login)
        {
            var user = _userRepo.GetByLogin(login);
            return user;
        }
    }
}
