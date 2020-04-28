using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Extensions;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal
{
    public class MyBrokenPageContext : DbContext
    {
        public MyBrokenPageContext(DbContextOptions<MyBrokenPageContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSecurityAnswer>().HasKey(ua => new { ua.UserId, ua.SecurityQuestionId });

            modelBuilder.Entity<UserSecurityAnswer>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.SecurityAnswers)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserSecurityAnswer>()
                .HasOne(ua => ua.SecurityQuestion)
                .WithMany(q => q.SecurityAnswers)
                .HasForeignKey(ua => ua.SecurityQuestionId);

            modelBuilder.AddInitialData();
        }
    }
}
