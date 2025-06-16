using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Expenses.AnyAsync()) return;

        var expenses = new List<Expense>
        {
            new()
            {
                Description = "Dinner",
                Amount = 600,
                PaidBy = "Shantanu",
                Shares = new List<ExpenseShare>
                {
                    new() { Person = "Shantanu", ShareAmount = 200 },
                    new() { Person = "Sanket", ShareAmount = 200 },
                    new() { Person = "Om", ShareAmount = 200 }
                }
            },
            new()
            {
                Description = "Groceries",
                Amount = 450,
                PaidBy = "Sanket",
                Shares = new List<ExpenseShare>
                {
                    new() { Person = "Shantanu", ShareAmount = 150 },
                    new() { Person = "Sanket", ShareAmount = 150 },
                    new() { Person = "Om", ShareAmount = 150 }
                }
            },
            new()
            {
                Description = "Petrol",
                Amount = 300,
                PaidBy = "Om",
                Shares = new List<ExpenseShare>
                {
                    new() { Person = "Shantanu", ShareAmount = 100 },
                    new() { Person = "Sanket", ShareAmount = 100 },
                    new() { Person = "Om", ShareAmount = 100 }
                }
            },
            new()
            {
                Description = "Movie Tickets",
                Amount = 500,
                PaidBy = "Shantanu",
                Shares = new List<ExpenseShare>
                {
                    new() { Person = "Shantanu", ShareAmount = 167 },
                    new() { Person = "Sanket", ShareAmount = 167 },
                    new() { Person = "Om", ShareAmount = 166 }
                }
            },
            new()
            {
                Description = "Pizza",
                Amount = 280,
                PaidBy = "Sanket",
                Shares = new List<ExpenseShare>
                {
                    new() { Person = "Shantanu", ShareAmount = 93.33m },
                    new() { Person = "Sanket", ShareAmount = 93.33m },
                    new() { Person = "Om", ShareAmount = 93.34m }
                }
            }
        };

        await context.Expenses.AddRangeAsync(expenses);
        await context.SaveChangesAsync();
    }
}
