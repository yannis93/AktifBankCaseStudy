using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<IResponseWrapper<bool>>
    {
        public Guid Id { get; set; }
        public AddressUpdateDto Address { get; set; }
    }
    
    public class AddressUpdateDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
    }
}
