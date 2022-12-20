using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepo : IMainRepo<User>
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(User entity)
        {
            await _db.User.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _db.User.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _db.User.FirstOrDefaultAsync(x => x.Login == login);
        }

        public IEnumerable<User> Select()
        {
            return _db.User.ToList();
        }
    }
}
