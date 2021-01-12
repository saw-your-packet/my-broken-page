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
                new User { Id = 2, Username = "simple-user", Password = "7c4a8d09ca3762af61e59520943dc26494f8941b", RoleId = 2 },
                new User { Id = 3, Username = "tony", Password = "949582b373f672911d5ada89ee57cd0ab9235bb2", RoleId = 2 },
                new User { Id = 4, Username = "pam", Password = "710c1dba8446624483dcd59b650bb22b50db1eba", RoleId = 2 },
                new User { Id = 5, Username = "meredith", Password = "8d162b20bf0891e75a4b6888d67415721431f089", RoleId = 2 },
                new User { Id = 6, Username = "elliot", Password = "31320896aedc8d3d1aaaee156be885ba0774da73", RoleId = 2 },
                new User { Id = 7, Username = "sheldon", Password = "910706c961d74c0393dd965499cd4efa69fee419", RoleId = 2 },
                new User { Id = 8, Username = "dwight", Password = "eb637419ca49dbdcc5c7e4beca623e323185307a", RoleId = 2 },
                new User { Id = 9, Username = "trebor", Password = "613f3a67885597fee0a52fd97d011aa698abee4a", RoleId = 2 },
                new User { Id = 10, Username = "matilda", Password = "8e3e4fdd3e830cbd02404bfb28bab7ca21b19893", RoleId = 2 }
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
