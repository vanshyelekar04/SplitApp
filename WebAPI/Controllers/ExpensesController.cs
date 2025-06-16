using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("expenses")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _service;

    public ExpensesController(IExpenseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExpenses()
    {
        var result = await _service.GetAllExpensesAsync();
        return Ok(new { success = true, data = result });
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { success = false, message = "Invalid input." });

        var result = await _service.CreateExpenseAsync(request);
        return Ok(new { success = true, data = result, message = "Expense added successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(Guid id, [FromBody] UpdateExpenseRequest request)
    {
        try
        {
            var result = await _service.UpdateExpenseAsync(id, request);
            return Ok(new { success = true, data = result, message = "Expense updated successfully" });
        }
        catch (Exception ex)
        {
            return NotFound(new { success = false, message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(Guid id)
    {
        var result = await _service.DeleteExpenseAsync(id);
        if (!result)
            return NotFound(new { success = false, message = "Expense not found" });

        return Ok(new { success = true, message = "Expense deleted successfully" });
    }

    [HttpGet("settlements")]
    public async Task<ActionResult<List<SettlementSummary>>> GetSettlements()
    {
        var settlements = await _service.GetSettlementsAsync();
        return Ok(settlements);
    }
}
