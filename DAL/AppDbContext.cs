using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        //конструктор (для работы в MVC - startup)
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        //добавим сущность User
        public DbSet<User> User { get; set; }

    }
}
