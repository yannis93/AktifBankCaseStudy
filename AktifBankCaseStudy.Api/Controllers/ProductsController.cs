using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using AktifBankCaseStudy.Application.Products.Commands.UpdateProduct;
using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using AktifBankCaseStudy.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AktifBankCaseStudy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var query = new GetProductsQuery();
        var result = await _mediator.Send(query, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductCommand command, CancellationToken cancellationToken = default)
  
    {
        var result = await _mediator.Send(command, cancellationToken);
    
        if (result.IsSuccess)
            return Ok(result.Response);
    
        return NotFound();
    }
}