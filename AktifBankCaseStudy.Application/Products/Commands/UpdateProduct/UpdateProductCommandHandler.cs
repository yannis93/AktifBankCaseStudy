using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, IResponseWrapper<bool>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(
        ILogger<UpdateProductCommandHandler> logger,
        IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<IResponseWrapper<bool>> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        ProductSpecification productSpecification = new ProductSpecification(request.Id);
        Product product = await _productRepository.GetBySpecAsync(productSpecification);
        if (product == null)
            throw new NotFoundException("Product not found");
        product.Update(request.Name, request.Barcode, request.Description, request.Quantity, request.Price);
        await _productRepository.UpdateAsync(product);
        await _productRepository.UnitOfWork.SaveEntitiesAsync();
        return new ResponseWrapper<bool>(true);
    }
}