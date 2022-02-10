using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsiApp.Models;
using PetsiApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsiApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<CareActivity> CareActivities { get; set; }
        public DbSet<LoggedActivity> LoggedActivities { get; set; }

        //public override int SaveChanges()
        //{
        //    AddTimestamps();
        //    return base.SaveChanges();
        //}

        //private void AddTimestamps()
        //{
        //    var entities = ChangeTracker.Entries().Where(x => x.Entity is LoggedActivity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        //    foreach (var entity in entities)
        //    {

        //     ((LoggedActivity)entity.Entity).LogTime = DateTime.UtcNow.ToString();
        //    }
        //}
    }
}
