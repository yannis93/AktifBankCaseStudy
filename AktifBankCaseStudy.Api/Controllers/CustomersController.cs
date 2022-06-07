using AktifBankCaseStudy.Application.Customers.Commands.UpdateCustomer;
using AktifBankCaseStudy.Application.Customers.Queries.GetCustomers;
using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AktifBankCaseStudy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCustomerQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var query = new GetCustomersQuery();
        var result = await _mediator.Send(query, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
}