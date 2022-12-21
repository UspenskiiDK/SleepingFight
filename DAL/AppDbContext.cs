using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

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
            mb.Entity<User>(entity =>
            {
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Login).IsRequired();
                entity.Property(x => x.Password).IsRequired();
            });


        }

       
    }
}
