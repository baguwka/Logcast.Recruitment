﻿using Logcast.Recruitment.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logcast.Recruitment.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Audio> Audios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subscription>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Audio>().HasIndex(p => p.FileId).IsUnique();
        }
    }
}