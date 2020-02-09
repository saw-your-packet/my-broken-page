using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal
{
    public class MyBrokenPageContext : DbContext
    {
        public MyBrokenPageContext(DbContextOptions<MyBrokenPageContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "user" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin", RoleId = 1 },
                new User { Id = 2, Username = "me", Password = "123456", RoleId = 2 }
                );
        }
    }
}
