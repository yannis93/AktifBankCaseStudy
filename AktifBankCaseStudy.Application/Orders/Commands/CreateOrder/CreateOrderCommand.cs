using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<IResponseWrapper<Guid>>
    {
        public List<ProductDto> Products { get; set; }
        public Guid CustomerId { get; set; }
        public AddressCreateDto Address { get; set; }
    }

    public class ProductDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
    public class AddressCreateDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
    }
}
