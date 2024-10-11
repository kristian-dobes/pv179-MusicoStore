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
            var users = PrepareUserModels();
            var posts = PreparePostModels();
            var comments = PrepareCommentModels();

            modelBuilder.Entity<OrderItem>()
                .HasData(users);

            modelBuilder.Entity<Product>()
                .HasData(posts);

            modelBuilder.Entity<Order>()
                .HasData(comments);
        }

        private static List<Order> PrepareCommentModels()
        {
            return new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    Content = "Bad ....",
                    UserId = 2,
                    PostId = 1,
                },
            };
        }

        private static List<Product> PreparePostModels()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Title = "Post Title :)",
                    Content = "Very nice content",
                    UserId = 1,
                },
            };
        }

        private static List<OrderItem> PrepareUserModels()
        {
            return new List<OrderItem>()
            {
                new OrderItem()
                {
                    Id = 1,
                    Username = "Jozko",
                    Created = new DateTime(2020, 11, 10),
                },

                new OrderItem()
                {
                    Id = 2,
                    Username = "Ferko",
                    Created = new DateTime(2022, 1, 22),
                },
            };
        }
    }
}
