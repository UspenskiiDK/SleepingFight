using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IUserBL
    {
        public IEnumerable<User> GetAll();
    }
}
