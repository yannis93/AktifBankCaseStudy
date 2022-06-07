using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;

namespace AktifBankCaseStudy.Infrastructure.EfCore.Repositories;

public class ProductRepository: EFRepository<Product>, IProductRepository
{
    public ProductRepository(AktifBankDbContext context) : base(context)
    { }
}