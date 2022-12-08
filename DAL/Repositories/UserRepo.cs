using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext db)
        {
            _db = db;
        }

        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select()
        {
            return _db.User.ToList();
        }
    }
}
