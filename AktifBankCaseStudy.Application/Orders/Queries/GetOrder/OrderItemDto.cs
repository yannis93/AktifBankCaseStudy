using AktifBankCaseStudy.Application.SeedWork.Mappings;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AutoMapper;

namespace AktifBankCaseStudy.Application.Orders.Queries.GetOrder;

public partial class OrderItemDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public partial class OrderItemDto : IMapFrom<OrderItem>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, OrderItemDto>();
    }
}