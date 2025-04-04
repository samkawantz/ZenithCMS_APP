using Microsoft.EntityFrameworkCore;
using ZenithCMS.Models;
using System;
using BCrypt.Net;


namespace ZenithCMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<ServicePage> ServicePages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<ProjectDetail> ProjectDetails { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial user with hashed password
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    // Hashed password
                    Email = "admin@example.com",
                    Role = "Admin"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}