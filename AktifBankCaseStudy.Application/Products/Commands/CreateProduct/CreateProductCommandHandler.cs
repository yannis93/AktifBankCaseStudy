using AktifBankCaseStudy.Application.Products.Commands.UpdateProduct;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, IResponseWrapper<bool>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(
        ILogger<CreateProductCommandHandler> logger,
        IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<IResponseWrapper<bool>> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        Product product = new Product(Guid.NewGuid(), request.Name, request.Barcode, request.Description, request.Quantity, request.Price);
       
        await _productRepository.AddAsync(product);
        await _productRepository.UnitOfWork.SaveEntitiesAsync();
        return new ResponseWrapper<bool>(true);
    }
}