using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.SharedKernel.SeedWork;
using AktifBankCaseStudy.SharedKernel.SeedWork.Utils;

namespace AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;

public class OrderItem: Entity
{
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    
    public Guid OrderId { get; private set; }
    public virtual Order Order { get; private set; }
    
    public Guid ProductId { get; private set; }
    public virtual Product Product { get; private set; }

    protected OrderItem()
    {
        
    }
    public OrderItem(Guid id, Guid orderId, Guid productId, decimal price, int quantity)
    {
        Check.HasValue(id, nameof(id));
        Check.Positive(price, nameof(price));
        Check.Positive(quantity, nameof(quantity));

        this.Id = id;
        this.OrderId = orderId;
        this.ProductId = productId;
        this.UnitPrice = price;
        this.Quantity = quantity;
    }
    public void AddQuantity(int quantity)
    {
        if (quantity < 0)
            throw new DomainException("Invalid quantity");

        this.Quantity += quantity;
        this.UpdatedOn = DateTime.UtcNow;
    }

    public void Delete()
    {
        DeletedOn = DateTime.Now;
    }

    public void SetDateTime(DateTime now)
    {
        this.CreatedOn = now;
    }
}