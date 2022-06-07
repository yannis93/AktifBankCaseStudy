using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AktifBankCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class OrderItemEntityConfiguration: IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItem");

        builder.HasKey(b => b.Id); //PK
        
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.DeletedOn);
        builder.Property(p => p.UpdatedOn);

        /* Ignore s */
        builder.Ignore(p => p.DomainEvents);
    }
}