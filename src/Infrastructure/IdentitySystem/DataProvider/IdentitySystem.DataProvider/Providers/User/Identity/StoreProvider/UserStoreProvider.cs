using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserStoreProvider : IUserStore<CoreUser>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }

    public DbSet<DataUser> UserDbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public UserStoreProvider(IdentitySystemDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;

        UserDbSet = DbContext.Set<DataUser>();
    }
    #endregion

    #region [ Internal - Method ]
    protected virtual Guid ParseId(string id)
        => Mapper.Map<Guid>(id);

    [DebuggerStepThrough]
    protected virtual DataUser? MapToDataModel(CoreUser? entity)
        => Mapper.Map<DataUser?>(entity);

    [DebuggerStepThrough]
    protected virtual CoreUser? MapToEntity(DataUser? dbEntity)
        => Mapper.Map<CoreUser?>(dbEntity);

    [DebuggerStepThrough]
    protected virtual IEnumerable<DataUser> MapToDbEntities(IEnumerable<CoreUser?> entities)
        => Mapper.Map<IEnumerable<DataUser>>(entities);

    [DebuggerStepThrough]
    protected virtual IEnumerable<CoreUser> MapToEntities(IEnumerable<DataUser?> entities)
        => Mapper.Map<IEnumerable<CoreUser>>(entities);

    protected virtual async Task<DataUser?> InternalFindByUserIdAsync(string id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var mId = ParseId(id!);
        var query = UserDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbUser = await query.FirstOrDefaultAsync(x => x.Id!.Equals(mId), cancellationToken);
        return dbUser;
    }
    #endregion

    #region [ Public - Methods ]
    #region [ Set ]
    public Task SetUserNameAsync(CoreUser user, string? userName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        user.UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        return Task.CompletedTask;

    }

    public Task SetNormalizedUserNameAsync(CoreUser user, string? normalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        user.NormalizedUserName = normalizedName ?? throw new ArgumentNullException(nameof(normalizedName));
        return Task.CompletedTask;
    }
    #endregion

    #region [ Get ]
    public Task<string> GetUserIdAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        return Task.FromResult(user.Id);
    }

    public Task<string?> GetUserNameAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        return Task.FromResult(user.UserName);
    }

    public Task<string?> GetNormalizedUserNameAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        return Task.FromResult(user.NormalizedUserName);
    }

    #region [ Fillter ]
    public async Task<CoreUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (userId == null)
            throw new ArgumentNullException(nameof(userId));
        var dbUser = await InternalFindByUserIdAsync(userId, true, cancellationToken);
        return MapToEntity(dbUser);

    }

    public async Task<CoreUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (normalizedUserName == null)
            throw new ArgumentNullException(nameof(normalizedUserName));
        var query = UserDbSet.AsQueryable().AsNoTracking();
        var dbUser = await query.FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName, cancellationToken);
        return MapToEntity(dbUser);
    }
    #endregion

    #endregion

    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var dbUser = MapToDataModel(user);
        ArgumentNullException.ThrowIfNull(dbUser, nameof(dbUser));

        UserDbSet.Add(dbUser);
        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not create user {dbUser.UserName}. A user with this name may already exist." });
        }

        return IdentityResult.Success;
    }
    #endregion

    #region [ Update ]
    public async Task<IdentityResult> UpdateAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        var dbUser = await InternalFindByUserIdAsync(user.Id, disableQuickFind, cancellationToken);

        ArgumentNullException.ThrowIfNull(dbUser, nameof(dbUser));

        Mapper.Map(user, dbUser);
        UserDbSet.Update(dbUser);

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not update user {dbUser.UserName}. The user may not exist." });
        }

        return IdentityResult.Success;
    }
    #endregion

    #region [ Delete ]
    public async Task<IdentityResult> DeleteAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        var dbUser = await InternalFindByUserIdAsync(user.Id, disableQuickFind, cancellationToken);
        ArgumentNullException.ThrowIfNull(dbUser, nameof(dbUser));

        UserDbSet.Remove(dbUser);
        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {dbUser.UserName}. The user may not exist." });
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
