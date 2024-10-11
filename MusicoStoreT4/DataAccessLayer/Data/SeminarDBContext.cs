using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class SeminarDBContext : DbContext
    {
        public DbSet<OrderItem> Users { get; set; }
        public DbSet<Order> Comments { get; set; }
        public DbSet<Product> Posts { get; set; }

        public SeminarDBContext(DbContextOptions<SeminarDBContext> options) : base(options)
        {

        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var dbPath = Path.Join(Environment.GetFolderPath(folder), "seminar03.db");

            optionsBuilder
                .UseSqlite($"Data Source={dbPath}")
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .UseLazyLoadingProxies()
                ;
        }
        */
        // https://docs.microsoft.com/en-us/ef/core/modeling/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setup the delete method for all of the entities using reflexion
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.SetNull;
            }

            /* one-to-many relationship */

            modelBuilder.Entity<Product>()
                .HasOne(post => post.Creator)
                .WithMany(user => user.Posts)
                .HasForeignKey(post => post.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(comment => comment.Post)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(comment => comment.Commenter)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
