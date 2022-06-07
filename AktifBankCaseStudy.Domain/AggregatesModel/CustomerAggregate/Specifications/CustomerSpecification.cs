using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using Ardalis.Specification;

namespace AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate.Specifications;

public class CustomerSpecification: Specification<Customer>, ISingleResultSpecification
{
    public CustomerSpecification(Guid id)
    {
        Query.Where(p => p.Id == id);
    }
}