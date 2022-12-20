using Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IRegistrationBL
    {
        Task<ClaimsIdentity> Register(Registration reg);

        public ClaimsIdentity Authenticate(User user);
        public ClaimsIdentity Login(Login log);
    }
}
