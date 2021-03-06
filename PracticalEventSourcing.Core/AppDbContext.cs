﻿using Microsoft.EntityFrameworkCore;
using PracticalEventSourcing.Core.EventStoreAccessors;
using PracticalEventSourcing.Core.ReadModels;

namespace PracticalEventSourcing.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<EventStore> EventStore { get; set; }
        public DbSet<ProductRM> Products { get; set; }
        public DbSet<CartRM> Carts { get; set; }
        public DbSet<CartItemRM> CartItems { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductRMMap());
            modelBuilder.ApplyConfiguration(new CartRMMap());
            modelBuilder.ApplyConfiguration(new CartItemRMMap());
        }
    }
}
