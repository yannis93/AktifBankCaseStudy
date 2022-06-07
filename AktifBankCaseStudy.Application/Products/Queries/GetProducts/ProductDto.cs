using AktifBankCaseStudy.Application.SeedWork.Mappings;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AutoMapper;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProducts;

public partial class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
public partial class ProductDto : IMapFrom<Product>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>();
    }
}