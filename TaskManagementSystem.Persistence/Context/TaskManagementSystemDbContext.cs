using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Persistence.Context;

public class TaskManagementSystemDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskManagementSystemDb;Trusted_Connection=True");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    
}