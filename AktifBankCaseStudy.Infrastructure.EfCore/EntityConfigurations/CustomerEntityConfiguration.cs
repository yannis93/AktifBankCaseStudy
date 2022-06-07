using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AktifBankCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class CustomerEntityConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(b => b.Id); //PK

        builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        builder.OwnsOne(x => x.Address);

        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.DeletedOn);
        builder.Property(p => p.UpdatedOn);

        /* Ignore s */
        builder.Ignore(p => p.DomainEvents);
        
        builder.HasData(new
        {
            Id = Guid.Parse("bbe4041a-18c4-43f5-b361-bf6320732a45"),
            Name = "John Doe",
            CreatedOn = DateTime.Now
        });
        builder.OwnsOne(e => e.Address)
            .HasData(new
            {
                CustomerId = Guid.Parse("bbe4041a-18c4-43f5-b361-bf6320732a45"),
                Street = "Çınar sokak",
                City = "İstanbul",
                Country = "Türkiye",
                Zipcode = "34000",
                Description = "Yeni yüzyıl mahallesi çınar sokak"
            });
    }
}