using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddInitialData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "user" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "d033e22ae348aeb5660fc2140aec35850c4da997", RoleId = 1 },
                new User { Id = 2, Username = "me", Password = "7c4a8d09ca3762af61e59520943dc26494f8941b", RoleId = 2 }
                );

            modelBuilder.Entity<SecurityQuestion>().HasData(
                new SecurityQuestion { Id = 1, Question = "What company animal do you have?" },
                new SecurityQuestion { Id = 2, Question = "What color do you like the most?" },
                new SecurityQuestion { Id = 3, Question = "What high school you went to?" }
                );

            modelBuilder.Entity<UserSecurityAnswer>().HasData(
                new UserSecurityAnswer { UserId = 2, SecurityQuestionId = 1, Answer = "dog" },
                new UserSecurityAnswer { UserId = 2, SecurityQuestionId = 2, Answer = "blue" },
                new UserSecurityAnswer { UserId = 2, SecurityQuestionId = 3, Answer = "royal cbc" }
                );

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Content = "Hi guys! This secure site is awesome!!", UserId = 2 },
                new Post { Id = 2, Content = "I can post a lot of posts!", UserId = 2 }
                );

            return modelBuilder;
        }
    }
}
