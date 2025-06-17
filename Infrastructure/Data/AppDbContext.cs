using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<ExpenseShare> ExpenseShares => Set<ExpenseShare>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.Shares)
                  .WithOne() // This was missing the navigation property
                  .HasForeignKey(s => s.ExpenseId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExpenseShare>(entity =>
        {
            entity.HasKey(s => s.Id);
            // Add index for better performance
            entity.HasIndex(s => s.ExpenseId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
