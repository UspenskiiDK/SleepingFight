using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IUserBL
    {
        public IEnumerable<User> GetAll();
        public User GetUserByLogin(string login);
        public bool DeleteUser(string login);
        public bool AddUser(User user);
    }
}
