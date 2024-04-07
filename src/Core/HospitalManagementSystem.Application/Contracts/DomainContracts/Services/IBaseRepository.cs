namespace HospitalManagementSystem.Application;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null);

    Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken = default);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
