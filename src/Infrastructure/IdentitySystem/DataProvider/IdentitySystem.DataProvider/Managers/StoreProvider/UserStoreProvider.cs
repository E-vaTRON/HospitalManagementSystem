using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;
using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;
using CoreUserRole = IdentitySystem.Domain.UserRole;
using DataUserRole = IdentitySystem.DataProvider.UserRole;
using CoreUserClaim = IdentitySystem.Domain.UserClaim;
using DataUserClaim = IdentitySystem.DataProvider.UserClaim;
using IdentitySystem.Domain;
using System.Security.Claims;

namespace IdentitySystem.DataProvider;

public class UserStoreProvider : IUserStore<CoreUser>, 
                                 IQueryableUserStore<CoreUser>,  
                                 IUserPasswordStore<CoreUser>, 
                                 IUserEmailStore<CoreUser>, 
                                 IUserPhoneNumberStore<CoreUser>,  
                                 IUserRoleStore<CoreUser>, 
                                 IUserClaimStore<CoreUser>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }

    public DbSet<DataUser> UserDbSet { get; protected set; }

    public DbSet<DataRole> RoleDbSet { get; protected set; }

    public DbSet<DataUserRole> UserRoleDbSet { get; protected set; }

    public DbSet<DataUserClaim> UserClaimDbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public UserStoreProvider(IdentitySystemDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;

        UserDbSet = DbContext.Set<DataUser>();
        RoleDbSet = DbContext.Set<DataRole>();
        UserRoleDbSet = DbContext.Set<DataUserRole>();
        UserClaimDbSet = DbContext.Set<DataUserClaim>();
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
    protected virtual IEnumerable<CoreUser> MapToEntities(IEnumerable<DataUser?> entities)
        => Mapper.Map<IEnumerable<CoreUser>>(entities);
    #endregion

    #region [ Check ]
    private async Task InternalCleanseNonExistingUserRolesAsync(CoreUser user)
    {
        foreach (var userRole in user.UserRoles.ToList())
        {
            var dbUserRole = await InternalFindUserRoleByIdAsync(userRole.Id);
            if (dbUserRole == null)
            {
                user.UserRoles.Remove(userRole);
            }
        }
    }

    private async Task InternalCleanseNonExistingUserClaimsAsync(CoreUser user)
    {
        foreach (var userClaim in user.UserClaims.ToList())
        {
            var dbUserClaim = await InternalFindUserClaimByIdAsync(userClaim.Id);
            if (dbUserClaim == null)
            {
                user.UserClaims.Remove(userClaim);
            }
        }
    }
    #endregion

    #region [ Create ]
    public async Task InternalCreateUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var dbUserRole = new DataUserRole { UserId = userId, RoleId = roleId };

        await UserRoleDbSet.AddAsync(dbUserRole);
    }

    public async Task InternalCreateUserClaimAsync(DataUser user, Claim claim, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var dbUserClaim = new DataUserClaim { UserId = user.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
        
        user.UserClaims.Add(dbUserClaim);

        await UserClaimDbSet.AddAsync(dbUserClaim);
    }
    #endregion

    #region [ Get ]
    protected virtual async Task<List<DataUserClaim>> InternalGetUserClaimByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var userMId = ParseId(userId);
        var userClaims = await UserClaimDbSet
            .Where(ur => ur.UserId == userMId).ToListAsync(cancellationToken);
        return userClaims;
    }

    protected virtual async Task<List<DataUser>> InternalGetUserByClaimAsync(Claim claim, CancellationToken cancellationToken)
    {
        var user = await UserDbSet.Include(u => u.UserClaims)
            .Where(u => u.UserClaims.Any(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value))
            .ToListAsync(cancellationToken);
        return user;
    }

    protected virtual async Task<List<DataUserRole>> InternalGetUserRolesByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var userMId = ParseId(userId);
        var userRoles = await UserRoleDbSet
            .Where(ur => ur.UserId == userMId).Include(ur => ur.Role).ToListAsync(cancellationToken);
        return userRoles;
    }

    protected virtual async Task<List<DataUserRole>> InternalGetUserRolesByRoleIdAsync(string roleId, CancellationToken cancellationToken)
    {
        var roleMId = ParseId(roleId);
        var userRoles = await UserRoleDbSet
            .Where(ur => ur.RoleId == roleMId).ToListAsync(cancellationToken);
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

    protected virtual async Task<DataRole?> InternalFindRoleByIdAsync(string id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = RoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbRole = await query.FirstOrDefaultAsync(x => x.Id!.Equals(id), cancellationToken);
        return dbRole;
    }

    protected virtual async Task<DataRole?> InternalFindRoleByNameAsync(string normalizedName, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = RoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbRole = await query.FirstOrDefaultAsync(x => x.NormalizedName!.Equals(normalizedName), cancellationToken);
        return dbRole;
    }

    protected virtual async Task<DataUserRole?> InternalFindUserRoleByIdAsync(string userId, string roleId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var userMId = ParseId(userId);
        var roleMId = ParseId(roleId);

        var query = UserRoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbUserRole = await query.FirstOrDefaultAsync(x => x.UserId == userMId && x.RoleId == roleMId, cancellationToken);
        return dbUserRole;
    }

    protected virtual async Task<DataUserRole?> InternalFindUserRoleByIdAsync(string userRoleId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var userRoleMId = ParseId(userRoleId);

        var query = UserRoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbUserRole = await query.FirstOrDefaultAsync(x => x.Id == userRoleMId, cancellationToken);
        return dbUserRole;
    }

    protected virtual async Task<DataUserClaim?> InternalFindUserClaimByIdAsync(int userClaimId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {

        var query = UserClaimDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbUserClaim = await query.FirstOrDefaultAsync(x => x.Id == userClaimId, cancellationToken);
        return dbUserClaim;
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

        await InternalCleanseNonExistingUserRolesAsync(user);
        await InternalCleanseNonExistingUserClaimsAsync(user);

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

    #region [ Public - IQueryable - Methods ]
    public IQueryable<CoreUser> Users => UserDbSet.AsQueryable().ProjectTo<CoreUser>(Mapper.ConfigurationProvider);

    //public IQueryable<CoreUser> Users
    //{
    //    get
    //    {
    //        var query = UserDbSet.AsQueryable();

    //        return query.ProjectTo<CoreUser>(Mapper.ConfigurationProvider)!;
    //    }

    //}
    #endregion

    #region [ Public - UserRole - Methods ]
    #region [ Get ]
    public async Task<IList<string>> GetRolesAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var userRoles = await InternalGetUserRolesByUserIdAsync(user.Id, cancellationToken);
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

        var dbUserRoles = await InternalGetUserRolesByRoleIdAsync(dbRole.Id.ToString(), cancellationToken);
        var dbUsers = dbUserRoles.Select(x => x.User).ToList();

        var users = MapToEntities(dbUsers).ToList();
        return users;
    }
    #endregion

    #region [ Add ]
    public async Task AddToRoleAsync(CoreUser user, string roleNormalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleNormalizedName, nameof(roleNormalizedName));

        var role = await InternalFindRoleByNameAsync(roleNormalizedName);
        if (role == null)
            throw new ArgumentException($"Role with NormalizedName: '{roleNormalizedName}' does not exist.");

        var userId = ParseId(user.Id);
        await InternalCreateUserRoleAsync(userId, role.Id, cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Check ]
    public async Task<bool> IsInRoleAsync(CoreUser user, string roleNormalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleNormalizedName, nameof(roleNormalizedName));

        var dbRole = await InternalFindRoleByNameAsync(roleNormalizedName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleNormalizedName}' does not exist.");

        var userRole = await InternalFindUserRoleByIdAsync(user.Id, dbRole.Id.ToString());

        return userRole != null;
    }
    #endregion

    #region [ Remove ]
    public async Task RemoveFromRoleAsync(CoreUser user, string roleNormalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(roleNormalizedName, nameof(roleNormalizedName));

        var dbRole = await InternalFindRoleByNameAsync(roleNormalizedName);
        if (dbRole == null)
            throw new ArgumentException($"Role '{roleNormalizedName}' does not exist.");

        var userRole = await InternalFindUserRoleByIdAsync(user.Id, dbRole.Id.ToString());
        if (userRole == null)
            throw new ArgumentException($"User is not in role '{roleNormalizedName}'.");

        userRole.IsDeleted = true;
        userRole.DeleteOn = DateTime.UtcNow;

        DbContext.Remove(userRole);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion
    #endregion

    #region [ Public - Claim - Methods ]
    #region [ Get ]
    public async Task<IList<Claim>> GetClaimsAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var userClaims = await InternalGetUserClaimByUserIdAsync(user.Id, cancellationToken);

        var claims = new List<Claim>();
        foreach (var userClaim in userClaims)
        {
            if (!string.IsNullOrEmpty(userClaim.ClaimType) && !string.IsNullOrEmpty(userClaim.ClaimValue))
            {
                claims.Add(new Claim(userClaim.ClaimType, userClaim.ClaimValue));
            }
        }

        return claims;
    }

    public async Task<IList<CoreUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(claim, nameof(claim));

        var dbUsers = await InternalGetUserByClaimAsync(claim, cancellationToken);
        return MapToEntities(dbUsers).ToList();
    }
    #endregion

    #region [ Add ]
    public async Task AddClaimsAsync(CoreUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(claims, nameof(claims));

        var dbUser = await InternalFindUserByIdAsync(user.Id, true, cancellationToken);
        ArgumentNullException.ThrowIfNull(dbUser, nameof(dbUser));

        foreach (var claim in claims)
        {
            await InternalCreateUserClaimAsync(dbUser, claim, cancellationToken);
        }

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Update - Replace ]
    public async Task ReplaceClaimAsync(CoreUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(claim, nameof(claim));
        ArgumentNullException.ThrowIfNull(newClaim, nameof(newClaim));

        var userClaims = await InternalGetUserClaimByUserIdAsync(user.Id, cancellationToken);
        var matchedClaim = userClaims.First(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value);

        matchedClaim.ClaimValue = newClaim.Value;
        matchedClaim.ClaimType = newClaim.Type;

        await DbContext.SaveChangesAsync(cancellationToken);

        throw new NotImplementedException();
    }
    #endregion

    #region [ Remove ]
    public async Task RemoveClaimsAsync(CoreUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(claims, nameof(claims));

        var userClaims = await InternalGetUserClaimByUserIdAsync(user.Id, cancellationToken);
        foreach (var claim in claims)
        {
            foreach (var matchedClaim in userClaims)
            {
                UserClaimDbSet.Remove(matchedClaim);
            }
        }
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

    #region [ Public - PhoneNumber - Methods ]
    #region [ Get ]
    #region [ Filter ]
    public async Task<CoreUser?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        var dbUser = await UserDbSet.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);
        return MapToEntity(dbUser);
    }
    #endregion
    #endregion
    public Task SetPhoneNumberAsync(CoreUser user, string? phoneNumber, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.PhoneNumber = phoneNumber;
        return Task.CompletedTask;
    }

    public Task<string?> GetPhoneNumberAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        return Task.FromResult(user.PhoneNumber);
    }

    public Task<bool> GetPhoneNumberConfirmedAsync(CoreUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        return Task.FromResult(user.PhoneNumberConfirmed);
    }

    public Task SetPhoneNumberConfirmedAsync(CoreUser user, bool confirmed, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.PhoneNumberConfirmed = confirmed;
        return Task.CompletedTask;
    }
    #endregion

    public void Dispose()
    {
        DbContext?.Dispose();
    }
}
