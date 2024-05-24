using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;
using CoreRoleClaim = IdentitySystem.Domain.RoleClaim;
using DataRoleClaim = IdentitySystem.DataProvider.RoleClaim;

namespace IdentitySystem.DataProvider;

public class RoleStoreProvider : IRoleStore<CoreRole>, 
                                 IQueryableRoleStore<CoreRole>, 
                                 IRoleClaimStore<CoreRole>
{
    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }

    public DbSet<DataRole> RoleDbSet { get; protected set; }

    public DbSet<DataRoleClaim> RoleClaimDbSet { get; protected set; }
    #endregion

    #region [ CTor ]
    public RoleStoreProvider(IdentitySystemDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;

        RoleDbSet = DbContext.Set<DataRole>();
        RoleClaimDbSet = DbContext.Set<DataRoleClaim>();
    }
    #endregion

    #region [ Internal - Method ]
    #region [ Mapping ]
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
    #endregion

    #region [ Create ]
    protected async Task InternalCreateUserClaimAsync(DataRole role, Claim claim, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var dbUserClaim = new DataRoleClaim { RoleId = role.Id, ClaimType = claim.Type, ClaimValue = claim.Value };

        role.RoleClaims.Add(dbUserClaim);

        await RoleClaimDbSet.AddAsync(dbUserClaim);
    }
    #endregion

    #region [ Check ]
    protected async Task InternalCleanseNonExistingUserClaimsAsync(CoreRole role, CancellationToken cancellationToken = default!)
    {
        var disableQuickFind = false;
        foreach (var roleClaim in role.RoleClaims.ToList())
        {
            var dbUserClaim = await InternalFindRoleClaimByIdAsync(roleClaim.Id, disableQuickFind, cancellationToken);
            if (dbUserClaim == null)
            {
                role.RoleClaims.Remove(roleClaim);
            }
        }
    }
    #endregion

    #region [ Get ]
    protected virtual async Task<List<DataRoleClaim>> InternalGetRoleClaimByRoleIdAsync(string roleId, CancellationToken cancellationToken)
    {
        var roleMId = ParseId(roleId);
        var userClaims = await RoleClaimDbSet
            .Where(ur => ur.RoleId == roleMId).ToListAsync(cancellationToken);
        return userClaims;
    }

    #region [ Get - Single ]
    protected virtual async Task<DataRole?> InternalFindByIdAsync(string id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var mId = ParseId(id!);
        var query = RoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.Id!.Equals(mId), cancellationToken);
    }

    protected virtual async Task<DataRole?> InternalFindByNameAsync(string normalizedName, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = RoleDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.NormalizedName!.Equals(normalizedName), cancellationToken);
    }

    protected virtual async Task<DataRoleClaim?> InternalFindRoleClaimByIdAsync(int roleClaimId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = RoleClaimDbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        var dbRoleClaim = await query.FirstOrDefaultAsync(x => x.Id == roleClaimId, cancellationToken);
        return dbRoleClaim;
    }
    #endregion
    #endregion
    #endregion

    #region [ Public - Role - Methods ]
    #region [ Set ]
    public Task SetRoleNameAsync(CoreRole role, string? roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        role.Name = roleName ?? throw new ArgumentNullException(nameof(roleName));
        return Task.CompletedTask;

    }

    public Task SetNormalizedRoleNameAsync(CoreRole role, string? normalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        role.NormalizedName = normalizedName ?? throw new ArgumentNullException(nameof(normalizedName));
        return Task.CompletedTask;
    }
    #endregion

    #region [ Get ]
    public Task<string> GetRoleIdAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        return Task.FromResult(role.Id.ToString());
    }

    public Task<string?> GetRoleNameAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        return Task.FromResult(role.Name);
    }

    public Task<string?> GetNormalizedRoleNameAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        return Task.FromResult(role.NormalizedName); throw new NotImplementedException();
    }
    #region [ Get - Single ]
    public async Task<CoreRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        ArgumentNullException.ThrowIfNull(roleId, nameof(roleId));

        var dbRole = await InternalFindByIdAsync(roleId, disableQuickFind, cancellationToken);

        return MapToEntity(dbRole);

    }
    public async Task<CoreRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        ArgumentNullException.ThrowIfNull(normalizedRoleName, nameof(normalizedRoleName));

        var dbRole = await InternalFindByNameAsync(normalizedRoleName, disableQuickFind, cancellationToken);

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

        RoleDbSet.Add(dbRole);
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

        await InternalCleanseNonExistingUserClaimsAsync(role, cancellationToken);

        Mapper.Map(role, dbRole);
        RoleDbSet.Update(dbRole);

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

        RoleDbSet.Remove(dbRole);
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
    #endregion

    #region [ Public - IQuerable - Methods ]
    public IQueryable<CoreRole> Roles => RoleDbSet.AsQueryable().ProjectTo<CoreRole>(Mapper.ConfigurationProvider);
    #endregion

    #region [ Public - Claim - Methods ]
    #region [ Get ]
    public async Task<IList<Claim>> GetClaimsAsync(CoreRole role, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));

        var roleClaims = await InternalGetRoleClaimByRoleIdAsync(role.Id, cancellationToken);
        ArgumentNullException.ThrowIfNull(roleClaims, nameof(roleClaims));

        var claims = new List<Claim>();
        foreach (var roleClaim in roleClaims)
        {
            if (!string.IsNullOrEmpty(roleClaim.ClaimType) && !string.IsNullOrEmpty(roleClaim.ClaimValue))
            {
                claims.Add(new Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
            }
        }

        return claims;
    }
    #endregion

    #region [ Add ]
    public async Task AddClaimAsync(CoreRole role, Claim claim, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var disableQuickFind = false;
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        ArgumentNullException.ThrowIfNull(claim, nameof(claim));

        var dbRole = await InternalFindByIdAsync(role.Id, disableQuickFind, cancellationToken);
        ArgumentNullException.ThrowIfNull(dbRole, nameof(dbRole));

        await InternalCreateUserClaimAsync(dbRole, claim, cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region [ Remove ]
    public async Task RemoveClaimAsync(CoreRole role, Claim claim, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        ArgumentNullException.ThrowIfNull(claim, nameof(claim));

        var roleClaims = await InternalGetRoleClaimByRoleIdAsync(role.Id, cancellationToken);
        ArgumentNullException.ThrowIfNull(roleClaims, nameof(roleClaims));

        var matchedClaim = roleClaims.First(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value);

        matchedClaim.IsDeleted = true;
        matchedClaim.DeleteOn = DateTime.UtcNow;
        RoleClaimDbSet.Remove(matchedClaim);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion
    #endregion

    public void Dispose()
    {
        DbContext?.Dispose();
    }
}