using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("")]
public class SettlementsController : ControllerBase
{
    private readonly IExpenseService _service;

    public SettlementsController(IExpenseService service)
    {
        _service = service;
    }

    [HttpGet("people")]
    public async Task<IActionResult> GetPeople()
    {
        var result = await _service.GetPeopleAsync();
        return Ok(new { success = true, data = result });
    }

    [HttpGet("balances")]
    public async Task<IActionResult> GetBalances()
    {
        var result = await _service.GetBalancesAsync();
        return Ok(new { success = true, data = result });
    }

    [HttpGet("settlements")]
    public async Task<IActionResult> GetSettlements()
    {
        var result = await _service.GetSettlementsAsync();
        return Ok(new { success = true, data = result });
    }
}
