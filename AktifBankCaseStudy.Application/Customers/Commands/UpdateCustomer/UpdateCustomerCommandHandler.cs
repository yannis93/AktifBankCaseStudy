using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, IResponseWrapper<bool>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<UpdateCustomerCommandHandler> _logger;

    public UpdateCustomerCommandHandler(
        ILogger<UpdateCustomerCommandHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<IResponseWrapper<bool>> Handle(UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        CustomerSpecification spec = new CustomerSpecification(request.Id);
        var customer = await _customerRepository.GetBySpecAsync(spec);
        if (customer != null)
        {
            customer.Update(request.Name, new Address(request.Address.Street, request.Address.City,
                request.Address.Country, request.Address.ZipCode, request.Address.Description));

            await _customerRepository.UpdateAsync(customer);
        }else
        {
            throw new Exception("Customer not found");
        }

        await _customerRepository.UnitOfWork.SaveEntitiesAsync();
        return new ResponseWrapper<bool>(true);
    }
}