using CoreUser = IdentitySystem.Domain.User;
using DTOUserIn = IdentitySystem.Application.InputUserDTO;
using DTOUserOut = IdentitySystem.Application.OutputUserDTO;

namespace IdentitySystem.ServiceProvider;

public class UserServiceProvider : IdentityServiceProviderBase<DTOUserOut, DTOUserIn, CoreUser>, IUserServiceProvider
{
    #region [ Field ]
    private readonly ISignInProvider SignInProvider;
    private readonly IUserDataProvider UserDataProvider;
    #endregion

    #region [ CTor ]
    public UserServiceProvider(IUserDataProvider dataProvider, ISignInProvider signInProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        SignInProvider = signInProvider;
        UserDataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Set ]
    public async Task<IdentityResult> SetUserNameAsync(DTOUserIn userDto, string userName)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.SetUserNameAsync(user, userName);
    }
    #endregion

    #region [ Create ]
    public async Task<IdentityResult> CreateAsync(DTOUserIn userDto, string password)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.CreateAsync(user, password);
    }

    //public Task<IdentityResult> CreateAsync(DTOUser userDto)
    //{
    //    var user = MapToEntity(userDto);
    //    ArgumentNullException.ThrowIfNull(user, nameof(user));
    //    return DataProvider.CreateAsync(user);
    //}
    #endregion

    #region [ Read ]
    //public IQueryable<DTOUser> FindAll(Expression<Func<DTOUser, bool>>? dtoPredicate = null)
    //{
    //    var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
    //    var entities = DataProvider.FindAll(entityPredicate);
    //    return MapToDTOs(entities).AsQueryable();
    //}

    //public async Task<IReadOnlyCollection<DTOUser>> FindByMultipleGuidsAsync(string[] userGuids)
    //{
    //    var users = await DataProvider.FindByMultipleGuidsAsync(userGuids);
    //    return MapToDTOs(users).ToList().AsReadOnly();
    //}

    //public async Task<DTOUser?> FindByIdAsync(string userId)
    //{
    //    ArgumentNullException.ThrowIfNull(userId, nameof(userId));
    //    var user = await DataProvider.FindByIdAsync(userId);
    //    return MapToDTO(user);
    //}

    public async Task<DTOUserOut?> FindByEmailAsync(string email)
    {
        ArgumentNullException.ThrowIfNull(email, nameof(email));
        var user = await UserDataProvider.FindByEmailAsync(email);
        return MapToDTO(user);
    }

    public async Task<DTOUserOut?> FindByPhoneNumberAsync(string phoneNumber)
    {
        ArgumentNullException.ThrowIfNull(phoneNumber, nameof(phoneNumber));
        var user = await UserDataProvider.FindByPhoneNumberAsync(phoneNumber);
        return MapToDTO(user);
    }

    //public async Task<DTOUser?> FindByNameAsync(string normalizedUserName)
    //{
    //    ArgumentNullException.ThrowIfNull(normalizedUserName, nameof(normalizedUserName));
    //    var user = await DataProvider.FindByNameAsync(normalizedUserName);
    //    return MapToDTO(user);
    //}
    #endregion

    #region [ Update ]
    //public async Task<IdentityResult> UpdateAsync(DTOUserIn userDto)
    //{
    //    var user = MapToEntity(userDto);
    //    ArgumentNullException.ThrowIfNull(user, nameof(user));
    //    return await DataProvider.UpdateAsync(user);
    //}
    #endregion

    #region [ Delete ]
    //public async Task<IdentityResult> DeleteAsync(DTOUser userDto)
    //{
    //    var user = MapToEntity(userDto);
    //    ArgumentNullException.ThrowIfNull(user, nameof(user));
    //    return await DataProvider.DeleteAsync(user);
    //}
    #endregion

    #region [ Check ]
    public async Task<SignInResult> CheckPasswordSignInAsync(DTOUserIn userDto, string password, LoginMode mode, bool lockoutOnFailure)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        switch (mode)
        {
            case LoginMode.Email:
                if (user.Email is not null)
                {
                    var result = await UserDataProvider.FindByEmailAsync(user.Email);
                    return result is not null ? await SignInProvider.CheckPasswordSignInAsync(result, password, lockoutOnFailure)
                                              : SignInResult.Failed;
                }
                break;
            case LoginMode.PhoneNumber:
                if (user.PhoneNumber is not null)
                {
                    var result = await UserDataProvider.FindByPhoneNumberAsync(user.PhoneNumber);
                    return result is not null ? await SignInProvider.CheckPasswordSignInAsync(result, password, lockoutOnFailure)
                                              : SignInResult.Failed;
                }
                break;
        }
        return SignInResult.Failed;
    }
    #endregion

    #region [ Role ]
    public async Task<IList<string>> GetRolesAsync(DTOUserIn userDto)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.GetRolesAsync(user);
    }

    public async Task<IdentityResult> AddToRoleAsync(DTOUserIn userDto, string role)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.AddToRoleAsync(user, role);
    }

    public async Task<IdentityResult> RemoveFromRoleAsync(DTOUserIn userDto, string role)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.RemoveFromRoleAsync(user, role);
    }
    #endregion

    #region [ Claim ]
    //public async Task<IList<Claim>> GetClaimsAsync(DTOUserIn userDto)
    //{
    //    var user = MapToEntity(userDto);
    //    ArgumentNullException.ThrowIfNull(user, nameof(user));
    //    return await DataProvider.GetClaimsAsync(user);
    //}

    //public async Task<IdentityResult> AddClaimAsync(DTOUserIn userDto, Claim claim)
    //{
    //    var user = MapToEntity(userDto);
    //    ArgumentNullException.ThrowIfNull(user, nameof(user));
    //    return await DataProvider.AddClaimAsync(user, claim);
    //}

    //public async Task<IdentityResult> RemoveClaimAsync(DTOUser userDto, Claim claim)
    //{
    //    var user = MapToEntity(userDto);
    //    ArgumentNullException.ThrowIfNull(user, nameof(user));
    //    return await DataProvider.RemoveClaimAsync(user, claim);
    //}
    #endregion

    #region [ Password ]
    public async Task<bool> HasPasswordAsync(DTOUserIn userDto)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.HasPasswordAsync(user);
    }

    public async Task<bool> CheckPasswordAsync(DTOUserIn userDto, string password)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(password, nameof(password));
        return await UserDataProvider.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResult> ChangePasswordAsync(DTOUserIn userDto, string currentPassword, string newPassword)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(currentPassword, nameof(currentPassword));
        ArgumentNullException.ThrowIfNull(newPassword, nameof(newPassword));
        return await UserDataProvider.ChangePasswordAsync(user, currentPassword, newPassword);
    }
    #endregion
    #endregion
}
