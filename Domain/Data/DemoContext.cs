
using Domain.Data.Configurations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace Domain.Data;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Course { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<Student> Student { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.ApplyConfiguration(new Configurations.CourseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PersonConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.StudentConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
