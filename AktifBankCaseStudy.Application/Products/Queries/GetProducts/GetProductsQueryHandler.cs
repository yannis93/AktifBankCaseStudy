using AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;
using AktifBankCaseStudy.Application.Customers.Queries.GetCustomers;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, IResponseWrapper<List<ProductDto>>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetCustomersQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(
        IMapper mapper,
        ILogger<GetCustomersQueryHandler> logger,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<IResponseWrapper<List<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.ListAsync(cancellationToken);

        if (products == null)
            throw new NotFoundException("Products not found");

        return new ResponseWrapper<List<ProductDto>>(_mapper.Map<List<Product>, List<ProductDto>>(products));
    }
}