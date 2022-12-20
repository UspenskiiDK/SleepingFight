using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUserBL
    {
        public IEnumerable<User> GetAll();
        Task<User> GetUserByLogin(string login);
        Task DeleteUser(string login);
        Task AddUser(User user);
    }
}
