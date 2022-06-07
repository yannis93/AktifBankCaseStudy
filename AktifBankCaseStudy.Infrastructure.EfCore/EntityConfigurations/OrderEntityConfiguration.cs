using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AktifBankCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class OrderEntityConfiguration: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(b => b.Id); //PK
        builder.OwnsOne(x => x.Delivery);

        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.DeletedOn);
        builder.Property(p => p.UpdatedOn);

        /* Ignore s */
        builder.Ignore(p => p.DomainEvents);
    }
}