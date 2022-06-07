using AktifBankCaseStudy.SharedKernel.SeedWork;

namespace AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;

public class Product: Entity, IAggregateRoot
{
    public Product(Guid id, string name, string barcode, string description, int quantity, decimal price)
    {
        Id = id;
        Name = name;
        Barcode = barcode;
        Description = description;
        Quantity = quantity;
        Price = price;
    }

    protected Product()
    {
        
    }
    public string Name { get; private set; }
    public string Barcode { get; private set; }
    public string Description { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public void Update( string name, string barcode, string description, int quantity, decimal price)
    {
        Name = name;
        Barcode = barcode;
        Description = description;
        Quantity = quantity;
        Price = price;
    }
    
}