using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Data;

public class DatabaseTaskDbContext : DbContext
{
    public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
        : base(options)
    {
    }

    // Keep the existing table name because it is already represented by the initial migration.
    public DbSet<Employee> Employee => Set<Employee>();

    public DbSet<Child> Children => Set<Child>();
}
