using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;

namespace AktifBankCaseStudy.Infrastructure.EfCore.Repositories;

public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AktifBankDbContext context) : base(context)
    {
    }
}
