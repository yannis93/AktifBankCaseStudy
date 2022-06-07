using AktifBankCaseStudy.Application.SeedWork.Mappings;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AutoMapper;

namespace AktifBankCaseStudy.Application.Orders.Queries.GetOrder;

public partial class AddressDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string Description { get; set; }
}
public partial class AddressDto : IMapFrom<Address>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Address, AddressDto>();
    }
}