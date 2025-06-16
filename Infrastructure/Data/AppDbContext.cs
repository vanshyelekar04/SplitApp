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
        modelBuilder.Entity<Expense>()
            .HasMany(e => e.Shares)
            .WithOne()
            .HasForeignKey(s => s.ExpenseId)
            .OnDelete(DeleteBehavior.Cascade);

        var shantanuId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var sanketId = Guid.Parse("22222222-2222-2222-222222222222");
        var omId = Guid.Parse("33333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = shantanuId, Name = "Shantanu" },
            new Person { Id = sanketId, Name = "Sanket" },
            new Person { Id = omId, Name = "Om" }
        );

        base.OnModelCreating(modelBuilder);
    }
}
