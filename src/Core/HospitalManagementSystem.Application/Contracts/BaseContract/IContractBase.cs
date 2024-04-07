namespace HospitalManagementSystem.Application;

public interface IContractBase<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);

    Task<TEntity?> FindByIdAsync(string id, CancellationToken cancellationToken = default!, bool isQuickFind = true);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default!);

    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default!);

    Task AddRangeAsync(CancellationToken cancellationToken = default!, params TEntity[] entities);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default!);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default!);

    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default!);

    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default!);
}
