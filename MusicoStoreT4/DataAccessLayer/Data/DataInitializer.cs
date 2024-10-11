using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = PrepairUserModels();
            var posts = PrepairPostModels();
            var comments = PrepairCommentModels();

            modelBuilder.Entity<User>()
                .HasData(users);

            modelBuilder.Entity<Post>()
                .HasData(posts);

            modelBuilder.Entity<Comment>()
                .HasData(comments);
        }

        private static List<Comment> PrepairCommentModels()
        {
            return new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Content = "Bad ....",
                    UserId = 2,
                    PostId = 1,
                },
            };
        }

        private static List<Post> PrepairPostModels()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Post Title :)",
                    Content = "Very nice content",
                    UserId = 1,
                },
            };
        }

        private static List<User> PrepairUserModels()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "Jozko",
                    Created = new DateTime(2020, 11, 10),
                },

                new User()
                {
                    Id = 2,
                    Username = "Ferko",
                    Created = new DateTime(2022, 1, 22),
                },
            };
        }
    }
}
