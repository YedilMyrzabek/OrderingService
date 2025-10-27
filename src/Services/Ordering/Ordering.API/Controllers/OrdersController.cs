using Microsoft.AspNetCore.Mvc;
using Ordering.Application.DTOs;
using Ordering.Application.Interfaces;

namespace Ordering.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto.OrderReadDto>> Create(
        [FromBody] OrderDto.OrderCreateDto dto, 
        CancellationToken ct)
    {
        var created = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { created.Id });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderDto.OrderReadDto>> GetById(Guid id, CancellationToken ct)
    {
        var res = await _service.GetByIdAsync(id, ct);

        if (res is null)
        {
            return NotFound();
        }
        
        return Ok(res);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<OrderDto.OrderReadDto>>> GetPaged(
        [FromQuery] int pageIndex = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken ct = default)
    {
        var result = await _service.GetPagedAsync(pageIndex, pageSize, ct);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<OrderDto.OrderReadDto>> Update(
        Guid id, 
        [FromBody] OrderDto.OrderUpdateDto dto, 
        CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, dto, ct);

        if (updated is null)
        {
            return NotFound();
        }
        
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        return await _service.DeleteAsync(id, ct) ? NoContent() : NotFound();
    }
}