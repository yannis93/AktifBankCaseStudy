using Ardalis.Specification;

namespace AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications
{
    public class ProductSpecification : Specification<Product>, ISingleResultSpecification
    {
        public ProductSpecification(Guid id)
        {
            Query.Where(p => p.Id == id);
        }
    }
}
