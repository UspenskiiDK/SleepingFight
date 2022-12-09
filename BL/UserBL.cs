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

        public IEnumerable<User> GetAll()
        {
            var users = _userRepo.Select();
            return users;
        }
    }
}
