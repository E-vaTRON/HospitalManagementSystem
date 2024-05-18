using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;
using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;
using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class UserRoleStoreProvider : UserStoreProvider,  IUserRoleStore<CoreUser>
{
    #region [ Field ]
    public DbSet<DataUserRole> UserRoleDbSet { get; protected set; }
    public DbSet<DataRole> RoleDbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public UserRoleStoreProvider( IdentitySystemDbContext dbContext, 
                                  IMapper mapper ) 
        : base(dbContext, mapper)
    {
        RoleDbSet = DbContext.Set<DataRole>();
        UserRoleDbSet = DbContext.Set<DataUserRole>();
    }
    #endregion

    #region [ Internal - Method ]
    public async Task CreateAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(userId, nameof(roleId));

        var dbUserRole = new DataUserRole { UserId = userId, RoleId = roleId };

        await UserRoleDbSet.AddAsync(dbUserRole);
    }

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
    protected virtual async Task<DataRole?> InternalFindByRoleNameAsync(string name, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = RoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbRole = await query.FirstOrDefaultAsync(x => x.Name!.Equals(name), cancellationToken);
        return dbRole;
    }

    protected virtual async Task<DataUserRole?> InternalFindUserRoleAsync(Guid userId, Guid roleId, bool asNoTracking = true, CancellationToken cancellationToken = default)
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

    #region [ Public - Methods ]
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

        var dbRole = await InternalFindByRoleNameAsync(roleName);
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

        var role = await InternalFindByRoleNameAsync(roleName);
        if (role == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var userId = ParseId(user.Id);
        await CreateAsync(userId, role.Id, cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Check ]
    public async Task<bool> IsInRoleAsync(CoreUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        var dbRole = await InternalFindByRoleNameAsync(roleName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var userId = ParseId(user.Id);
        var userRole = await InternalFindUserRoleAsync(userId, dbRole.Id);

        return userRole != null;
    }
    #endregion

    #region [ Remove ]
    public async Task RemoveFromRoleAsync(CoreUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));

        var dbRole = await InternalFindByRoleNameAsync(roleName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleName}' does not exist.");

        var userId = ParseId(user.Id);
        var userRole = await InternalFindUserRoleAsync(userId, dbRole.Id);
        if (userRole == null)
            throw new ArgumentException($"User is not in role '{roleName}'.");

        UserRoleDbSet.Remove(userRole);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion
    #endregion
}
