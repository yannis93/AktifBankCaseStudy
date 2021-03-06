using Ardalis.Specification;

namespace AktifBankCaseStudy.SharedKernel.SeedWork;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    IUnitOfWork UnitOfWork { get; }
    
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntity
{
}