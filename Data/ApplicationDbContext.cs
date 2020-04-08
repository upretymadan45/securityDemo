using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sqlinj.Models;

namespace sqlinj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<AppUser>().HasData(new AppUser{Id = -1, UserName="matt", Password="123"});

            builder.Entity<AppUser>().HasData(new AppUser{Id=-2, UserName="jack", Password="456"});

            base.OnModelCreating(builder);
        }
    }
}
