using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Entities;
using DAL.Interfaces;
using System.Linq;
using BL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BL
{
    public class RegistrationBL:IRegistrationBL
    {
        private readonly IMainRepo<User> _userRepo;
        public RegistrationBL(IMainRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ClaimsIdentity> Register(Registration reg)
        {
            

             var user = new User()
            {
                Login = reg.Login,
                Password = reg.Password,
                RegistrationDate = DateTime.Now
                
            };

            await _userRepo.Create(user);
            var result = Authenticate(user);

            return result;
        }


        public ClaimsIdentity Authenticate(User user)
        {
            var cl = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };
            return new ClaimsIdentity(cl,"ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        } 


        public ClaimsIdentity Login(Login log)
        {
            var user =  _userRepo.Select().FirstOrDefault(x => x.Login == log.login);
            var result = Authenticate(user);
            return result;
        }
    }
}
