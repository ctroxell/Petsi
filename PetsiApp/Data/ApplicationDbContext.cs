using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsiApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
            public DbSet<IdentityUser> ApplicationUsers { get; set; }
            public DbSet<Pet> Pets { get; set; }

    }
}
