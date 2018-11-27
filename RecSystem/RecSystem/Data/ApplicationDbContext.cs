using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecSystem.Models;

namespace RecSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemGenres> ItemGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
