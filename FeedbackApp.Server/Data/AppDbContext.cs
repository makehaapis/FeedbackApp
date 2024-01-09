using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FeedbackApp.Server.Data;
using System.Data;

namespace FeedbackApp.Server.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Feedback> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed AspNetUsers table with default admin user
            var hasher = new PasswordHasher<User>();

            var adminEmail = "admin@admin.com";
            var adminPassword = "Password123!";

            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111", // primary key
                    PasswordHash = hasher.HashPassword(null, adminPassword),
                    EmailAddress = adminEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = adminEmail.ToUpper(),
                    AccessFailedCount = 5,
                    LockoutEnabled = false,
                    Password = "password123!",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    Role = Role.Admin
                }
            );
        }
    }
}
