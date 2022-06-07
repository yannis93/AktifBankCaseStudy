using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;

namespace AktifBankCaseStudy.Infrastructure.EfCore.Repositories;

public class OrderRepository: EFRepository<Order>, IOrderRepository
{
    public OrderRepository(AktifBankDbContext context) : base(context)
    { }
}