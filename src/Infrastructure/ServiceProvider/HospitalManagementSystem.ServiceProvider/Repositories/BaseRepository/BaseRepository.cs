using HospitalManagementSystem.DataProvider;

namespace HospitalManagementSystem.ServiceProvider;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly HospitalManagementSystemDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(HospitalManagementSystemDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null)
        => _dbSet.WhereIf(predicate != null, predicate!);

    public virtual async Task<T?> FindByIdAsync(string Id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(Id);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}
