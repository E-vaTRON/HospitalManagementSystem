using IdentitySystem.Application;
using CoreRole = IdentitySystem.Domain.Role;
using DTORole = IdentitySystem.Application.RoleDTO;

namespace IdentitySystem.ServiceProvider;

public class RoleServiceProvider : IdentityServiceProviderBase<DTORole, CoreRole>, IRoleServiceProvider
{
    #region [ Field ]
    private readonly IRoleDataProvider DataProvider;
    #endregion

    #region [ CTor ]
    public RoleServiceProvider(IRoleDataProvider dataProvider, IMapper mapper) : base(mapper)
    {
        DataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Set ]
    public Task<IdentityResult> SetRoleNameAsync(DTORole roleDto, string roleName)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return DataProvider.SetRoleNameAsync(role, roleName);
    }
    #endregion

    #region[ Create ]
    public Task<IdentityResult> CreateAsync(DTORole roleDto)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return DataProvider.CreateAsync(role);
    }
    #endregion

    #region [ Read ]
    public IQueryable<DTORole> FindAll(Expression<Func<DTORole, bool>>? dtoPredicate = null)
    {
        var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
        var entities = DataProvider.FindAll(entityPredicate);
        return MapToDTOs(entities).AsQueryable();
    }

    public async Task<IReadOnlyCollection<DTORole>> FindByMultipleGuidsAsync(string[] userGuids)
    {
        var users = await DataProvider.FindByMultipleGuidsAsync(userGuids);
        return MapToDTOs(users).ToList().AsReadOnly();
    }

    public async Task<DTORole?> FindByIdAsync(string roleId)
    {
        ArgumentNullException.ThrowIfNull(roleId, nameof(roleId));
        var role = await DataProvider.FindByIdAsync(roleId);
        return MapToDTO(role);
    }

    public async Task<DTORole?> FindByNameAsync(string normalizedRoleName)
    {
        ArgumentNullException.ThrowIfNull(normalizedRoleName, nameof(normalizedRoleName));
        var role = await DataProvider.FindByNameAsync(normalizedRoleName);
        return MapToDTO(role);
    }
    #endregion

    #region [ Update ]
    public async Task<IdentityResult> UpdateAsync(DTORole roleDto)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return await DataProvider.UpdateAsync(role);
    }
    #endregion

    #region [ Delete ]
    public async Task<IdentityResult> DeleteAsync(DTORole roleDto)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return await DataProvider.DeleteAsync(role);
    }
    #endregion

    #region [ Check ]
    public async Task<bool> RoleExistsAsync(string roleName)
    {
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));
        return await DataProvider.RoleExistsAsync(roleName);
    }
    #endregion

    #region [ Claim ]
    public async Task<IdentityResult> AddClaimAsync(DTORole roleDto, Claim claim)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return await DataProvider.AddClaimAsync(role, claim);
    }

    public async Task<IList<Claim>> GetClaimsAsync(DTORole roleDto)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return await DataProvider.GetClaimsAsync(role);
    }

    public async Task<IdentityResult> RemoveClaimAsync(DTORole roleDto, Claim claim)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return await DataProvider.RemoveClaimAsync(role, claim);
    }
    #endregion
    #endregion
}
