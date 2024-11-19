namespace HospitalManagementSystem.Application;

public interface IContractBase<TOutputEntity, TInputEntity, TEId>
    where TOutputEntity : IEntity<TEId>
    where TInputEntity : IEntity<TEId>
{
    Task<IEnumerable<TOutputEntity>> FindAllWithPredicateAsync(Expression<Func<TInputEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<TOutputEntity>> FindAllAsync(CancellationToken cancellationToken = default);

    Task<TOutputEntity?> FindByIdAsync(TEId id, CancellationToken cancellationToken = default!, bool isQuickFind = true);

    Task AddAsync(TInputEntity entity, bool saveImmediately = true, CancellationToken cancellationToken = default!);

    Task AddRangeAsync(IEnumerable<TInputEntity> entities, bool saveImmediately = true, CancellationToken cancellationToken = default!);

    Task AddRangeAsync(CancellationToken cancellationToken = default!, bool saveImmediately = true, params TInputEntity[] entities);

    Task UpdateAsync(TInputEntity entity, CancellationToken cancellationToken = default!);

    Task DeleteAsync(TInputEntity entity, CancellationToken cancellationToken = default!);

    Task DeleteByIdAsync(TEId id, CancellationToken cancellationToken = default!);

    Task DeleteRangeAsync(IEnumerable<TInputEntity> entities, CancellationToken cancellationToken = default!);
}
