using CoreRole = IdentitySystem.Domain.Role;
using DTORoleIn = IdentitySystem.Application.InputRoleDTO;
using DTORoleOut = IdentitySystem.Application.OutputRoleDTO;

namespace IdentitySystem.ServiceProvider;

public class RoleServiceProvider : IdentityServiceProviderBase<DTORoleOut, DTORoleIn, CoreRole>, IRoleServiceProvider
{
    #region [ Field ]
    private readonly IRoleDataProvider RoleDataProvider;
    #endregion

    #region [ CTor ]
    public RoleServiceProvider(IRoleDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        RoleDataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Set ]
    public async Task<IdentityResult> SetRoleNameAsync(DTORoleIn roleDto, string roleName)
    {
        var role = MapToEntity(roleDto);
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        return await RoleDataProvider.SetRoleNameAsync(role, roleName);
    }
    #endregion

    //#region[ Create ]
    //public Task<IdentityResult> CreateAsync(DTORoleIn roleDto)
    //{
    //    var role = MapToEntity(roleDto);
    //    ArgumentNullException.ThrowIfNull(role, nameof(role));
    //    return DataProvider.CreateAsync(role);
    //}
    //#endregion

    //#region [ Read ]
    //public IQueryable<DTORoleOut> FindAll(Expression<Func<DTORoleIn, bool>>? dtoPredicate = null)
    //{
    //    var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
    //    var entities = DataProvider.FindAll(entityPredicate);
    //    return MapToDTOs(entities).AsQueryable();
    //}

    //public async Task<IReadOnlyCollection<DTORoleOut>> FindByMultipleGuidsAsync(string[] userGuids)
    //{
    //    var users = await DataProvider.FindByMultipleGuidsAsync(userGuids);
    //    return MapToDTOs(users).ToList().AsReadOnly();
    //}

    //public async Task<DTORoleOut?> FindByIdAsync(string roleId)
    //{
    //    ArgumentNullException.ThrowIfNull(roleId, nameof(roleId));
    //    var role = await DataProvider.FindByIdAsync(roleId);
    //    return MapToDTO(role);
    //}

    //public async Task<DTORoleOut?> FindByNameAsync(string normalizedRoleName)
    //{
    //    ArgumentNullException.ThrowIfNull(normalizedRoleName, nameof(normalizedRoleName));
    //    var role = await DataProvider.FindByNameAsync(normalizedRoleName);
    //    return MapToDTO(role);
    //}
    //#endregion

    //#region [ Update ]
    //public async Task<IdentityResult> UpdateAsync(DTORoleIn roleDto)
    //{
    //    var role = MapToEntity(roleDto);
    //    ArgumentNullException.ThrowIfNull(role, nameof(role));
    //    return await DataProvider.UpdateAsync(role);
    //}
    //#endregion

    //#region [ Delete ]
    //public async Task<IdentityResult> DeleteAsync(DTORoleIn roleDto)
    //{
    //    var role = MapToEntity(roleDto);
    //    ArgumentNullException.ThrowIfNull(role, nameof(role));
    //    return await DataProvider.DeleteAsync(role);
    //}
    //#endregion

    #region [ Check ]
    public async Task<bool> RoleExistsAsync(string roleName)
    {
        ArgumentNullException.ThrowIfNull(roleName, nameof(roleName));
        return await RoleDataProvider.RoleExistsAsync(roleName);
    }
    #endregion

    //#region [ Claim ]
    //public async Task<IdentityResult> AddClaimAsync(DTORoleIn roleDto, Claim claim)
    //{
    //    var role = MapToEntity(roleDto);
    //    ArgumentNullException.ThrowIfNull(role, nameof(role));
    //    return await DataProvider.AddClaimAsync(role, claim);
    //}

    //public async Task<IList<Claim>> GetClaimsAsync(DTORoleIn roleDto)
    //{
    //    var role = MapToEntity(roleDto);
    //    ArgumentNullException.ThrowIfNull(role, nameof(role));
    //    return await DataProvider.GetClaimsAsync(role);
    //}

    //public async Task<IdentityResult> RemoveClaimAsync(DTORoleIn roleDto, Claim claim)
    //{
    //    var role = MapToEntity(roleDto);
    //    ArgumentNullException.ThrowIfNull(role, nameof(role));
    //    return await DataProvider.RemoveClaimAsync(role, claim);
    //}
    //#endregion
    #endregion
}
