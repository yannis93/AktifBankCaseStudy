using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.Orders.Commands.UpdateOrder;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand: IRequest<IResponseWrapper<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public AddressUpdateDto Address { get; set; }
}