using AktifBankCaseStudy.SharedKernel.SeedWork;
using AktifBankCaseStudy.SharedKernel.SeedWork.Utils;

namespace AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;

public class Address : ValueObject
{
    public string Street { get; protected set; }
    public string City { get; protected set; }
    public string Country { get; protected set; }
    public string Zipcode { get; protected set; }
    public string Description { get; protected set; }

    public Address(string street, string city, string country, string zipcode, string description)
    {
        Check.NotNullOrEmpty(street, nameof(street));
        Check.NotNullOrEmpty(city, nameof(city));
        Check.NotNullOrEmpty(country, nameof(country));
        Check.NotNullOrEmpty(zipcode, nameof(zipcode));

        this.Street = street;
        this.City = city;
        this.Country = country;
        this.Zipcode = zipcode;
        this.Description = description;
    }

    protected Address()
    {
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return City;
        yield return Country;
        yield return Zipcode;
    }
}