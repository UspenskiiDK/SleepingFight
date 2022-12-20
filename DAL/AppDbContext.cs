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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>(mb =>
            {
                mb.Property(x => x.Id).ValueGeneratedOnAdd();
                mb.Property(x => x.Login).IsRequired();
                mb.Property(x => x.Password).IsRequired();
            });
        }

    }
}
