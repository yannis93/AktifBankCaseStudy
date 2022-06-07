using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AktifBankCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(b => b.Id); //PK

        builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        builder.Property(p => p.Barcode).IsRequired().HasMaxLength(250);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(250);

        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.DeletedOn);
        builder.Property(p => p.UpdatedOn);

        /* Ignore s */
        builder.Ignore(p => p.DomainEvents);
        
        builder.HasData(new Product(Guid.Parse("bbe4041a-18c4-43f5-b361-bf6320732a43"), "Iphone 11 256Gb", "443425252", "2 yıl apple garantili",1, 12500));
        builder.HasData(new Product(Guid.Parse("bbe4041a-18c4-43f5-b361-bf6320732a41"), "Iphone 11 Pro 256Gb", "433425252", "2 yıl apple garantili",1, 15500));
        builder.HasData(new Product(Guid.Parse("bbe4041a-18c4-43f5-b361-bf6320722a43"), "Iphone 13 Pro Max 256Gb", "422425252", "2 yıl apple garantili",1, 18500));

    }
}