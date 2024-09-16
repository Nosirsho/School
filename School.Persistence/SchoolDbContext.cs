﻿using Microsoft.EntityFrameworkCore;
using School.Core.Model;
using School.Persistence.Configurations;

namespace School.Persistence;

public class SchoolDbContext: DbContext
{
    public SchoolDbContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Host=localhost;Port=5432;Database=school;Username=postgres;Password=postgres;";
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.LogTo(System.Console.WriteLine);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new ParentConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Parent> Parents => Set<Parent>();
}