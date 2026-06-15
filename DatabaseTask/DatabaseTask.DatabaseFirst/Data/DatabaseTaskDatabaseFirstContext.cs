using System;
using System.Collections.Generic;
using DatabaseTask.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.DatabaseFirst.Data;

public partial class DatabaseTaskDatabaseFirstContext : DbContext
{
    public DatabaseTaskDatabaseFirstContext(DbContextOptions<DatabaseTaskDatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Child>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
