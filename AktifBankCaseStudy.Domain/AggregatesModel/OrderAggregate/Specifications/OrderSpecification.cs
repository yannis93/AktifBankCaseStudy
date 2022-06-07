using Ardalis.Specification;

namespace AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate.Specifications;

public class OrderSpecification: Specification<Order>, ISingleResultSpecification
{
    public OrderSpecification(Guid id)
    {
        Query.Include(x=>x.Customer)
             .Include(x=>x.OrderItems)
             .Where(p => p.Id == id && p.DeletedOn.HasValue == false);
    }
}