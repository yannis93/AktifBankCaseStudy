using AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;
using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using AktifBankCaseStudy.Application.Products.Queries.GetProducts;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler: IRequestHandler<GetCustomersQuery, IResponseWrapper<IEnumerable<CustomerDto>>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<GetCustomersQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(
        IMapper mapper,
        ILogger<GetCustomersQueryHandler> logger,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<IResponseWrapper<IEnumerable<CustomerDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        List<Customer> customers = await _customerRepository.ListAsync(cancellationToken);

        if (customers == null)
            throw new NotFoundException("Customers not found");

        return new ResponseWrapper<IEnumerable<CustomerDto>>(_mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers));
    }
}