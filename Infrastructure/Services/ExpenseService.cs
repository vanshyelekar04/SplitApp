using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;

    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ExpenseDTO> CreateExpenseAsync(CreateExpenseRequest request)
    {
        if (request.Amount <= 0) throw new ArgumentException("Amount must be positive");

        var expense = new Expense
        {
            Description = request.Description,
            Amount = request.Amount,
            PaidBy = request.PaidBy
        };

        int count = request.SharedWith.Count;
        var perHead = Math.Round(request.Amount / count, 2);

        foreach (var person in request.SharedWith)
        {
            expense.Shares.Add(new ExpenseShare
            {
                Person = person,
                ShareAmount = perHead
            });
        }

        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();

        return MapToDTO(expense);
    }

    public async Task<List<ExpenseDTO>> GetAllExpensesAsync()
    {
        var expenses = await _context.Expenses
            .Include(e => e.Shares)
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();

        return expenses.Select(MapToDTO).ToList();
    }

    public async Task<ExpenseDTO> UpdateExpenseAsync(Guid id, UpdateExpenseRequest request)
    {
        var expense = await _context.Expenses.Include(e => e.Shares)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (expense == null)
            throw new NotFoundException("Expense not found");

        expense.Amount = request.Amount;
        expense.Description = request.Description;
        expense.PaidBy = request.PaidBy;
        expense.Shares.Clear();

        var perHead = Math.Round(request.Amount / request.SharedWith.Count, 2);

        foreach (var person in request.SharedWith)
        {
            expense.Shares.Add(new ExpenseShare
            {
                Person = person,
                ShareAmount = perHead,
                ExpenseId = expense.Id
            });
        }

        await _context.SaveChangesAsync();
        return MapToDTO(expense);
    }

    public async Task<bool> DeleteExpenseAsync(Guid id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null) return false;

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<string>> GetPeopleAsync()
    {
        var people = await _context.ExpenseShares
            .Select(s => s.Person)
            .Union(_context.Expenses.Select(e => e.PaidBy))
            .Distinct()
            .ToListAsync();

        return people;
    }

    public async Task<Dictionary<string, decimal>> GetBalancesAsync()
    {
        var balances = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);

        var expenses = await _context.Expenses.Include(e => e.Shares).ToListAsync();

        foreach (var e in expenses)
        {
            balances.TryAdd(e.PaidBy, 0);
            balances[e.PaidBy] += e.Amount;

            foreach (var share in e.Shares)
            {
                balances.TryAdd(share.Person, 0);
                balances[share.Person] -= share.ShareAmount;
            }
        }

        return balances
            .ToDictionary(kvp => kvp.Key, kvp => Math.Round(kvp.Value, 2));
    }

    public async Task<List<SettlementSummary>> GetSettlementsAsync()
    {
        var balances = await GetBalancesAsync();

        var debtors = new List<KeyValuePair<string, decimal>>();
        var creditors = new List<KeyValuePair<string, decimal>>();

        foreach (var (person, balance) in balances)
        {
            if (balance < 0) debtors.Add(new(person, -balance));
            else if (balance > 0) creditors.Add(new(person, balance));
        }

        var settlements = new List<SettlementSummary>();
        int i = 0, j = 0;

        while (i < debtors.Count && j < creditors.Count)
        {
            var debtor = debtors[i];
            var creditor = creditors[j];
            var amount = Math.Min(debtor.Value, creditor.Value);

            settlements.Add(new SettlementSummary
            {
                From = debtor.Key,
                To = creditor.Key,
                Amount = Math.Round(amount, 2)
            });

            debtors[i] = new(debtor.Key, debtor.Value - amount);
            creditors[j] = new(creditor.Key, creditor.Value - amount);

            if (Math.Abs(debtors[i].Value) < 0.01m) i++;
            if (Math.Abs(creditors[j].Value) < 0.01m) j++;
        }

        return settlements;
    }

    private static ExpenseDTO MapToDTO(Expense e)
    {
        return new ExpenseDTO
        {
            Id = e.Id,
            Amount = e.Amount,
            Description = e.Description,
            PaidBy = e.PaidBy,
            CreatedAt = e.CreatedAt,
            Shares = e.Shares.Select(s => new ExpenseShareDTO
            {
                Person = s.Person,
                ShareAmount = s.ShareAmount
            }).ToList()
        };
    }
}
