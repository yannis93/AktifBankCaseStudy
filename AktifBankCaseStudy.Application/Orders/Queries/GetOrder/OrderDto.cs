using AktifBankCaseStudy.Application.SeedWork.Mappings;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AutoMapper;

namespace AktifBankCaseStudy.Application.Orders.Queries.GetOrder;

public partial class OrderDto
{
    public Guid Id { get; set; }
    public CustomerDto Customer { get; set; }
    public AddressDto Address { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
public partial class OrderDto : IMapFrom<Order>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Delivery))
            .ForMember(d => d.Customer, opt => opt.MapFrom(s => s.Customer))
            .ForMember(d => d.OrderItems, opt => opt.MapFrom(s => s.OrderItems));
    }
}