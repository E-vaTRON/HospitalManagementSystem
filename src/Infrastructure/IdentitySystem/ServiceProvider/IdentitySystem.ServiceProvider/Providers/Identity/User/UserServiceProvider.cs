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
    #endregion

    #region [ Read ]
    public async Task<DTOUserOut?> FindByEmailAsync(string normalizedEmail)
    {
        ArgumentNullException.ThrowIfNull(normalizedEmail, nameof(normalizedEmail));
        var user = await UserDataProvider.FindByEmailAsync(normalizedEmail);
        return MapToDTO(user);
    }

    public async Task<DTOUserOut?> FindByPhoneNumberAsync(string phoneNumber)
    {
        ArgumentNullException.ThrowIfNull(phoneNumber, nameof(phoneNumber));
        var user = await UserDataProvider.FindByPhoneNumberAsync(phoneNumber);
        return MapToDTO(user);
    }
    #endregion

    #region [ Check ]
    public async Task<SignInResult> CheckPasswordSignInAsync(DTOUserIn userDto, string password, LoginMode mode, bool lockoutOnFailure)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        return user is not null ? await SignInProvider.CheckPasswordSignInAsync(user, password, lockoutOnFailure)
                          : SignInResult.Failed;
    }
    #endregion

    #region [ Role ]
    public async Task<IList<string>> GetRolesAsync(DTOUserIn userDto)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.GetRolesAsync(user);
    }

    public async Task<IList<DTOUserOut>> GetUsersInRoleAsync(string roleNormalizedName)
    {
        ArgumentNullException.ThrowIfNull(roleNormalizedName, nameof(roleNormalizedName));
        var user = await UserDataProvider.GetUsersInRoleAsync(roleNormalizedName);
        return MapToDTOs(user).ToList();
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
    public async Task<string> GeneratePasswordResetTokenAsync(DTOUserIn userDto)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return await UserDataProvider.GeneratePasswordResetTokenAsync(user);
    }

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

    public async Task<IdentityResult> ResetPasswordAsync(DTOUserIn userDto, string token, string newPassword)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(token, nameof(token));
        ArgumentNullException.ThrowIfNull(newPassword, nameof(newPassword));
        return await UserDataProvider.ChangePasswordAsync(user, token, newPassword);
    }
    #endregion
    #endregion
}
