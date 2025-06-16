using Application.DTOs;

namespace Application.Interfaces;

public interface IExpenseService
{
    Task<ExpenseDTO> CreateExpenseAsync(CreateExpenseRequest request);
    Task<List<ExpenseDTO>> GetAllExpensesAsync();
    Task<ExpenseDTO> UpdateExpenseAsync(Guid id, UpdateExpenseRequest request);
    Task<bool> DeleteExpenseAsync(Guid id);

    Task<List<string>> GetPeopleAsync();
    Task<Dictionary<string, decimal>> GetBalancesAsync();
    Task<List<SettlementSummary>> GetSettlementsAsync();

}
