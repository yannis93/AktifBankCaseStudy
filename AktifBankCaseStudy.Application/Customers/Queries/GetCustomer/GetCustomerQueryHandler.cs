using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate.Specifications;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;

public class GetCustomerQueryHandler: IRequestHandler<GetCustomerQuery, IResponseWrapper<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<GetCustomerQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(
        IMapper mapper,
        ILogger<GetCustomerQueryHandler> logger,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<IResponseWrapper<CustomerDto>> Handle(GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        CustomerSpecification spec = new CustomerSpecification(request.Id);

        Customer customer = await _customerRepository.GetBySpecAsync(spec, cancellationToken);

        if (customer == null)
            throw new NotFoundException("Customer not found");

        return new ResponseWrapper<CustomerDto>(_mapper.Map<Customer, CustomerDto>(customer));
    }
}