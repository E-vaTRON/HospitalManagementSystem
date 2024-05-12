using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleStoreProvider : IRoleStore<CoreRole>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }

    public DbSet<DataRole> DbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public RoleStoreProvider(IdentitySystemDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;

        DbSet = DbContext.Set<DataRole>();
    }
    #endregion

    #region [ Internal - Method ]
    protected virtual Guid ParseId(string id)
        => Mapper.Map<Guid>(id);

    [DebuggerStepThrough]
    protected virtual DataRole? MapToDataModel(CoreRole? entity)
        => Mapper.Map<DataRole?>(entity);

    [DebuggerStepThrough]
    protected virtual CoreRole? MapToEntity(DataRole? dbEntity)
        => Mapper.Map<CoreRole?>(dbEntity);

    [DebuggerStepThrough]
    protected virtual IEnumerable<DataRole> MapToDbEntities(IEnumerable<CoreRole?> entities)
        => Mapper.Map<IEnumerable<DataRole>>(entities);

    protected virtual async Task<DataRole?> InternalFindByIdAsync(string id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var mId = ParseId(id!);
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbRole = await query.FirstOrDefaultAsync(x => x.Id!.Equals(mId), cancellationToken);
        return dbRole;
    }
    #endregion

    #region [ Public - Methods ]
    #region [ Set ]
    public Task SetRoleNameAsync(CoreRole role, string? roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        role.Name = roleName ?? throw new ArgumentNullException(nameof(roleName));
        return Task.CompletedTask;

    }

    public Task SetNormalizedRoleNameAsync(CoreRole role, string? normalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        role.NormalizedName = normalizedName ?? throw new ArgumentNullException(nameof(normalizedName));
        return Task.CompletedTask;
    }
    #endregion

    #region [ Get ]
    public Task<string> GetRoleIdAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        return Task.FromResult(role.Id);
    }

    public Task<string?> GetRoleNameAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        return Task.FromResult(role.Name);
    }

    public Task<string?> GetNormalizedRoleNameAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        return Task.FromResult(role.NormalizedName); throw new NotImplementedException();
    }
    #region [ Fillter ]
    public async Task<CoreRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (roleId == null)
            throw new ArgumentNullException(nameof(roleId));
        var dbUser = await InternalFindByIdAsync(roleId, true, cancellationToken);
        return MapToEntity(dbUser);

    }
    public async Task<CoreRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (normalizedRoleName == null)
            throw new ArgumentNullException(nameof(normalizedRoleName));
        var query = DbSet.AsQueryable().AsNoTracking();
        var dbRole = await query.FirstOrDefaultAsync(u => u.NormalizedName == normalizedRoleName, cancellationToken);
        return MapToEntity(dbRole);
    }
    #endregion

    #endregion

    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        var dbRole = MapToDataModel(role);
        ArgumentNullException.ThrowIfNull(dbRole, nameof(dbRole));

        DbSet.Add(dbRole);
        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not create role {dbRole.Name}. A role with this name may already exist." });
        }

        return IdentityResult.Success;
    }
    #endregion

    #region [ Update ]
    public async Task<IdentityResult> UpdateAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        var dbRole = await InternalFindByIdAsync(role.Id, disableQuickFind, cancellationToken);

        ArgumentNullException.ThrowIfNull(dbRole, nameof(dbRole));

        Mapper.Map(role, dbRole);
        DbSet.Update(dbRole);

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not update role {dbRole.Name}. The role may not exist." });
        }

        return IdentityResult.Success;
    }
    #endregion

    #region [ Delete ]
    public async Task<IdentityResult> DeleteAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        var dbRole = await InternalFindByIdAsync(role.Id, disableQuickFind, cancellationToken);
        ArgumentNullException.ThrowIfNull(dbRole, nameof(dbRole));

        DbSet.Remove(dbRole);
        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not delete role {dbRole.Name}. The role may not exist." });
        }

        return IdentityResult.Success;
    }
    #endregion

    public void Dispose()
    {
        DbContext?.Dispose();
    }
    #endregion
}
