using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.SharedKernel.SeedWork;
using AktifBankCaseStudy.SharedKernel.SeedWork.Utils;

namespace AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;

public class Order: Entity, IAggregateRoot
{
    public Order(Guid id, Guid customerId, Address delivery)
    {
        Id = id;
        CustomerId = customerId;
        Delivery = delivery;
        OrderItems = new HashSet<OrderItem>();
    }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public Address Delivery { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }
    
    protected Order () 
    {
        //Init
        OrderItems = new List<OrderItem>();
    }

    public void AddOrderItem(Guid orderItemId, Guid productId, decimal price, int quantity)
    {
        // var existOrderItem = OrderItems.SingleOrDefault(oi => oi.ProductId == productId);
        //
        // if (existOrderItem != null)
        // {
        //     existOrderItem.AddQuantity(quantity);
        // }
        // else
        // {
            var orderItem = new OrderItem(orderItemId, this.Id, productId, price, quantity);

            OrderItems.Add(orderItem);
        // }
    }

    public void RemoveOrderItem(Guid requestOrderItemId)
    {
        var orderItem = OrderItems.SingleOrDefault(oi => oi.Id == requestOrderItemId);

        if (orderItem != null)
        {
            OrderItems.Remove(orderItem);
        }
    }

    public void UpdateOrder(string addressCity, string addressStreet, string addressZipCode, string addressCountry, string addressDescription)
    { 
        Delivery = new Address(addressStreet, addressCity, addressCountry, addressZipCode, addressDescription);
    }

    public void Delete()
    {
        DeletedOn = DateTime.Now;
        foreach (var orderItem in OrderItems)
            orderItem.Delete();
    }
}