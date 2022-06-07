using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.Orders.Commands.CreateOrderItem;
using AktifBankCaseStudy.Application.Orders.Commands.DeleteOrder;
using AktifBankCaseStudy.Application.Orders.Commands.DeleteOrderItem;
using AktifBankCaseStudy.Application.Orders.Commands.UpdateOrder;
using AktifBankCaseStudy.Application.Orders.Queries.GetOrder;
using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AktifBankCaseStudy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetOrderQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPost("add-order-item/")]
    public async Task<IActionResult> Post(CreateOrderItemCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
        
    [HttpDelete("{orderId}/remove-order-item/{id}")]
    public async Task<IActionResult> Post(Guid id, Guid orderId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteOrderItemCommand(id, orderId);
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateOrderCommand command, CancellationToken cancellationToken = default)
  
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteOrderCommand(id);
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
}