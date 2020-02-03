using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal
{
    public class MyBrokenPageContext : DbContext
    {
        public MyBrokenPageContext(DbContextOptions<MyBrokenPageContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin" },
                new User { Id = 2, Username = "me", Password = "123456" });
        }
    }
}
