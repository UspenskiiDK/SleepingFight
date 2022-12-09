using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _db.User.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(User entity)
        {
            _db.User.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public User Get(int id)
        {
            return  _db.User.FirstOrDefault(x => x.Id == id);
        }

        public User GetByLogin(string login)
        {
            return _db.User.FirstOrDefault(x => x.Login == login);
        }

        public IEnumerable<User> Select()
        {
            return _db.User.ToList();
        }
    }
}
