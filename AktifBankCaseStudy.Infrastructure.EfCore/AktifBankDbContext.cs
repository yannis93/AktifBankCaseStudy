using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Infrastructure.EfCore.EntityConfigurations;
using AktifBankCaseStudy.SharedKernel.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AktifBankCaseStudy.Infrastructure.EfCore;

public class AktifBankDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public AktifBankDbContext(DbContextOptions<AktifBankDbContext> options) : base(options)
    {
    }

    public AktifBankDbContext(DbContextOptions<AktifBankDbContext> options, IMediator mediator) : base(options)
    {
        System.Diagnostics.Debug.WriteLine("AktifBankDbContext::ctor ->" + this.GetHashCode());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CustomerEntityConfiguration());
        builder.ApplyConfiguration(new ProductEntityConfiguration());
        builder.ApplyConfiguration(new OrderEntityConfiguration());
        builder.ApplyConfiguration(new OrderItemEntityConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await base.SaveChangesAsync(cancellationToken);
        
        return true;
    }

    /// <summary>
    /// WARNING! 
    /// This method can save all changes without raising any events!
    /// Use it just in transaction scope or non-domain process!
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}