using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;

namespace AktifBankCaseStudy.Infrastructure.EfCore.Repositories;

public class OrderItemRepository: EFRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AktifBankDbContext context) : base(context)
    { }
}