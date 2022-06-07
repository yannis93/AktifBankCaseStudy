
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IResponseWrapper<GetProducts.ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetProductQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(
        IMapper mapper,
        ILogger<GetProductQueryHandler> logger,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<IResponseWrapper<GetProducts.ProductDto>> Handle(GetProductQuery request,
        CancellationToken cancellationToken)
    {
        ProductSpecification spec = new ProductSpecification(request.Id);

        Product product = await _productRepository.GetBySpecAsync(spec, cancellationToken);

        if (product == null)
            throw new NotFoundException("Product not found");

        return new ResponseWrapper<GetProducts.ProductDto>(_mapper.Map<Product, GetProducts.ProductDto>(product));
    }
}