﻿namespace IdentitySystem.Application;

public interface IUserManagerProvider: IIdentityManagerProviderBase<User, string>
{
    #region [ Set ]
    Task<IdentityResult> SetUserNameAsync(User user, string userName);
    #endregion

    #region [ Create ]
    Task<IdentityResult> CreateAsync(User user, string password);
    #endregion

    #region [ Read ]
    Task<User?> FindByEmailAsync(string normalizedEmail);

    Task<User?> FindByPhoneNumberAsync(string phoneNumber);
    #endregion

    #region [ Role ]
    Task<IList<string>> GetRolesAsync(User user);

    Task<IList<User>> GetUsersInRoleAsync(string roleNormalizedName);

    Task<IdentityResult> AddToRoleAsync(User user, string roleNormalizedName);

    Task<IdentityResult> RemoveFromRoleAsync(User user, string role);
    #endregion

    #region [ Password ]
    Task<string> GeneratePasswordResetTokenAsync(User user);

    Task<bool> HasPasswordAsync(User user);

    Task<bool> CheckPasswordAsync(User user, string password);

    Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

    Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);
    #endregion
}