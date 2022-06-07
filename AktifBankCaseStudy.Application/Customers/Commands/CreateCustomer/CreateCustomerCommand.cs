using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Products.Commands.CreateProduct;

public class CreateCustomerCommand: IRequest<IResponseWrapper<bool>>
{
    public string Name { get; set; }
    public AddressCreateCustomerDto Address { get; set; }
}

public class AddressCreateCustomerDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string Description { get; set; }
}