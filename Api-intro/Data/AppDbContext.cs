﻿using Api_intro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace Api_intro.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupStudents> GroupStudents { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GroupStudents>()
                .HasKey(bc => new { bc.GroupId, bc.StudentId });
            builder.Entity<GroupStudents>()
                .HasOne(bc => bc.Group)
                .WithMany(b => b.GroupStudents)
                .HasForeignKey(bc => bc.GroupId);
            builder.Entity<GroupStudents>()
                .HasOne(bc => bc.Student)
                .WithMany(c => c.GroupStudents)
                .HasForeignKey(bc => bc.StudentId);

            builder.Entity<Country>().HasData(
              new Country { Id = 1, Name = "Azerbaycan", Population = 11000000 },
              new Country { Id = 2, Name = "Turkiye", Population = 60000000 }
            );
        }
    }
}
