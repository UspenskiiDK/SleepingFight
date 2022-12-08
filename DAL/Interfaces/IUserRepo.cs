using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserRepo : IMainRepo<User>
    {
        User GetByLogin(string login);
    }
}
