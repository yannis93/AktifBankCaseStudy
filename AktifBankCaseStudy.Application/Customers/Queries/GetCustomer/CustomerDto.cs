using AktifBankCaseStudy.Application.SeedWork.Mappings;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AutoMapper;

namespace AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;

public partial class CustomerDto
{
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