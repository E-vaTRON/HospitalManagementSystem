using CoreRole = IdentitySystem.Domain.Role;
using DataRole = IdentitySystem.DataProvider.Role;

namespace IdentitySystem.DataProvider;

public class RoleStoreProvider : IRoleStore<CoreRole>
{

    #region [ Field ]
    protected IMapper Mapper { get; set; }

    public IdentitySystemDbContext DbContext { get; protected set; }
    #endregion

    #region [ CTor ]
    public RoleStoreProvider(IdentitySystemDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
    }
    #endregion

    public async Task<IdentityResult> CreateAsync(CoreRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            ArgumentNullException.ThrowIfNull(role, nameof(role));
        DataRole dataRole = Mapper.Map<DataRole>(role);
        DbContext.Roles.Add(dataRole);
        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Could not create role {dataRole.Name}. A role with this name may already exist." });
        }

        return IdentityResult.Success;
    }

    public Task<IdentityResult> DeleteAsync(CoreRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<CoreRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CoreRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedRoleNameAsync(CoreRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetRoleIdAsync(CoreRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetRoleNameAsync(CoreRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedRoleNameAsync(CoreRole role, string? normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetRoleNameAsync(CoreRole role, string? roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(CoreRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
