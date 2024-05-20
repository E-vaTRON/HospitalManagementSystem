using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;
using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;
using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;

namespace IdentitySystem.DataProvider;

public class UserStoreProvider : IUserStore<CoreUser>, IUserPasswordStore<CoreUser>, IUserEmailStore<CoreUser>, IUserRoleStore<CoreUser>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }

    public DbSet<DataUser> UserDbSet { get; protected set; }

    public DbSet<DataUserRole> UserRoleDbSet { get; protected set; }

    public DbSet<DataRole> RoleDbSet { get; protected set; }
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
    #region [ Mapping ]
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
    #endregion

    #region [ Create ]
    public async Task InternalCreateUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(userId, nameof(roleId));

        var dbUserRole = new DataUserRole { UserId = userId, RoleId = roleId };

        await UserRoleDbSet.AddAsync(dbUserRole);
    }
    #endregion

    #region [ Get ]
    protected virtual async Task<List<DataUserRole>> GetUserRolesByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var userRoles = await UserRoleDbSet
            .Where(ur => ur.UserId == userId)
            .ToListAsync(cancellationToken);
        return userRoles;
    }

    protected virtual async Task<List<DataUserRole>> GetUserRolesByRoleIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        var userRoles = await UserRoleDbSet
            .Where(ur => ur.RoleId == roleId)
            .ToListAsync(cancellationToken);
        return userRoles;
    }

    #region [ Get - Single ]
    protected virtual async Task<DataUser?> InternalFindUserByIdAsync(string id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var mId = ParseId(id!);
        var query = UserDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.Id!.Equals(mId), cancellationToken);
    }

    protected virtual async Task<DataRole?> InternalFindRoleByNameAsync(string name, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = RoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbRole = await query.FirstOrDefaultAsync(x => x.Name!.Equals(name), cancellationToken);
        return dbRole;
    }

    protected virtual async Task<DataUserRole?> InternalFindUserRoleByIdAsync(Guid userId, Guid roleId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = UserRoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbUserRole = await query.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId, cancellationToken);
        return dbUserRole;
    }
    #endregion
    #endregion
    #endregion

    #region [ Public - User - Methods ]
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
        return Task.FromResult(user.Id.ToString());
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

    #region [ Get - Single ]
    public async Task<CoreUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (userId == null)
            throw new ArgumentNullException(nameof(userId));

        var dbUser = await InternalFindUserByIdAsync(userId, true, cancellationToken);
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
        var dbUser = await InternalFindUserByIdAsync(user.Id, disableQuickFind, cancellationToken);

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
        var dbUser = await InternalFindUserByIdAsync(user.Id, disableQuickFind, cancellationToken);
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
    #endregion

    #region [ Public - UserRole - Methods ]
    #region [ Get ]
    public async Task<IList<string>> GetRolesAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var userId = ParseId(user.Id);
        var userRoles = await GetUserRolesByUserIdAsync(userId, cancellationToken);
        var roles = userRoles.Select(userRole =>
        {
            ArgumentNullException.ThrowIfNull(userRole.Role, nameof(userRole.Role));
            return userRole.Role.Name ?? "No Named";
        }).ToList();

        return roles;
    }

    public async Task<IList<CoreUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        var dbRole = await InternalFindRoleByNameAsync(roleName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var dbUserRoles = await GetUserRolesByRoleIdAsync(dbRole.Id, cancellationToken);
        var dbUsers = dbUserRoles.Select(x => x.User).ToList();

        var users = MapToEntities(dbUsers).ToList();
        return users;
    }
    #endregion

    #region [ Add ]
    public async Task AddToRoleAsync(CoreUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        var role = await InternalFindRoleByNameAsync(roleName);
        if (role == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var userId = ParseId(user.Id);
        await InternalCreateUserRoleAsync(userId, role.Id, cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Check ]
    public async Task<bool> IsInRoleAsync(CoreUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        var dbRole = await InternalFindRoleByNameAsync(roleName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var userId = ParseId(user.Id);
        var userRole = await InternalFindUserRoleByIdAsync(userId, dbRole.Id);

        return userRole != null;
    }
    #endregion

    #region [ Remove ]
    public async Task RemoveFromRoleAsync(CoreUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        var dbRole = await InternalFindRoleByNameAsync(roleName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var userId = ParseId(user.Id);
        var userRole = await InternalFindUserRoleByIdAsync(userId, dbRole.Id);
        if (userRole == null)
            throw new ArgumentException($"User is not in role '{roleName}'.");

        UserRoleDbSet.Remove(userRole);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion
    #endregion

    #region [ Public - Password - Methods ]
    #region [ Set ]
    public async Task SetPasswordHashAsync(CoreUser user, string? passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Get ]
    public Task<string?> GetPasswordHashAsync(CoreUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }
    #endregion

    #region [ Check ]
    public Task<bool> HasPasswordAsync(CoreUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }
    #endregion
    #endregion

    #region [ Public - Email - Methods  ]
    #region [ Set ]
    public async Task SetEmailAsync(CoreUser user, string? email, CancellationToken cancellationToken)
    {
        user.Email = email;
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SetEmailConfirmedAsync(CoreUser user, bool confirmed, CancellationToken cancellationToken)
    {
        user.EmailConfirmed = confirmed;
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SetNormalizedEmailAsync(CoreUser user, string? normalizedEmail, CancellationToken cancellationToken)
    {
        user.NormalizedEmail = normalizedEmail;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Get ]
    public Task<string?> GetEmailAsync(CoreUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Email);
    }

    public Task<bool> GetEmailConfirmedAsync(CoreUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.EmailConfirmed);
    }
    public Task<string?> GetNormalizedEmailAsync(CoreUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.NormalizedEmail);
    }

    #region [ Filter ]
    public async Task<CoreUser?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    {
        var dbUser = await UserDbSet.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail, cancellationToken);
        return MapToEntity(dbUser);
    }
    #endregion
    #endregion
    #endregion

    public void Dispose()
    {
        DbContext?.Dispose();
    }
}
