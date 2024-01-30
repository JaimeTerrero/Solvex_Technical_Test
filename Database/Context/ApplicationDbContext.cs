using Database.Models;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            #region tables
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<User>().ToTable("Users");
            #endregion

            //#region relationships
            //modelBuilder.Entity<Project>()
            //    .HasMany<User>(project => project.Users)
            //    .WithOne(user => user.Project)
            //    .HasForeignKey(user => user.ProjectId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //#endregion

            #region
            modelBuilder.Entity<User>()
                .HasOne(u => u.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            //modelBuilder.Entity<User>().HasData(
            //   new User
            //   {
            //       Id = 1,
            //       Name = "admin",
            //       Username = "admin",
            //       Email = "admin@admin.com",
            //       Password = "admin",
            //       ProjectId = 1
            //   });

            #region "property configurations"

            #region project
            #endregion

            #endregion
        }
    }
}
