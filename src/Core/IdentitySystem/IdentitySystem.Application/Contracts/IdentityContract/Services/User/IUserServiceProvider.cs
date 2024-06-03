namespace IdentitySystem.Application;

public interface IUserServiceProvider : IIdentityServiceProviderBase<OutputUserDTO, InputUserDTO, string>
{
    #region [ Set ]
    Task<IdentityResult> SetUserNameAsync(InputUserDTO user, string userName);
    #endregion

    #region [ Check ]
    Task<SignInResult> CheckPasswordSignInAsync(InputUserDTO user, string password, LoginMode mode, bool lockoutOnFailure);
    #endregion

    #region [ Create ]
    Task<IdentityResult> CreateAsync(InputUserDTO user, string password);
    #endregion

    #region [ Read ]
    Task<OutputUserDTO?> FindByEmailAsync(string normalizedEmail);

    Task<OutputUserDTO?> FindByPhoneNumberAsync(string phoneNumber);
    #endregion

    #region [ Role ]
    Task<IList<string>> GetRolesAsync(InputUserDTO user);

    Task<IList<OutputUserDTO>> GetUsersInRoleAsync(string roleNormalizedName);

    Task<IdentityResult> AddToRoleAsync(InputUserDTO user, string roleNormalizedName);

    Task<IdentityResult> RemoveFromRoleAsync(InputUserDTO user, string role);
    #endregion

    #region [ Password ]
    Task<string> GeneratePasswordResetTokenAsync(InputUserDTO user);

    Task<bool> HasPasswordAsync(InputUserDTO user);

    Task<bool> CheckPasswordAsync(InputUserDTO user, string password);

    Task<IdentityResult> ChangePasswordAsync(InputUserDTO user, string currentPassword, string newPassword);

    Task<IdentityResult> ResetPasswordAsync(InputUserDTO user, string token, string newPassword);
    #endregion  
}
