using BOAProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Infrastructure
{
    public class BOAShopContext : DbContext
    {
        public BOAShopContext(DbContextOptions<BOAShopContext> opt) : base(opt)
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //USER TABLE
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.Cascade);
            //USER TABLE
            
            //ORDER TABLE
            modelBuilder.Entity<Order>()
                .HasKey(o => o.ID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address);
            //ORDER TABLE

            //PRODUCT TABLE
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Collection)
                .WithMany(c => c.Products);
            //PRODUCT TABLE

            //Collection TABLE
            modelBuilder.Entity<Collection>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Collection)
                .OnDelete(DeleteBehavior.SetNull);
            //Collection TABLE

            //Address TABLE
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithOne(u => u.Address)
                .OnDelete(DeleteBehavior.SetNull);
            //Address TABLE
        }




    }

   
   

}

