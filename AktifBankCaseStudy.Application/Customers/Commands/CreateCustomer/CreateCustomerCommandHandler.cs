using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, IResponseWrapper<bool>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CreateCustomerCommandHandler> _logger;

    public CreateCustomerCommandHandler(
        ILogger<CreateCustomerCommandHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<IResponseWrapper<bool>> Handle(CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        Customer customer = new Customer(Guid.NewGuid(), request.Name,
            new Address(request.Address.Street, request.Address.City,
                request.Address.Country, request.Address.ZipCode, request.Address.Description));
        
        await _customerRepository.AddAsync(customer);
        await _customerRepository.UnitOfWork.SaveEntitiesAsync();
        return new ResponseWrapper<bool>(true);
    }
}
