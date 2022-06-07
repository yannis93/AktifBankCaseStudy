using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.SharedKernel.SeedWork;

namespace AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;

public class Customer: Entity, IAggregateRoot
{
    public Customer(Guid id, string name, Address address)
    {
        Id = id;
        Name = name;
        Address = address;
        CreatedOn = DateTime.Now;
    }

    protected Customer()
    {
        
    }

    public string Name { get; private set; }
    public Address Address { get; private set; }
    
    public void Update(string name, Address address)
    {
        Name = name;
        Address = address;
        UpdatedOn = DateTime.Now;
    }
}