using AktifBankCaseStudy.Application.SeedWork.Mappings;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AutoMapper;

namespace AktifBankCaseStudy.Application.Orders.Queries.GetOrder;

public partial class CustomerDto{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
public partial class CustomerDto : IMapFrom<Customer>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomerDto>();
    }
}