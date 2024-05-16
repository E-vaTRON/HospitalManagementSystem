namespace IdentitySystem.Application;

public interface ISignInContractBase<TUser, TKey>
    where TUser : class
    where TKey : IEquatable<TKey>
{
    Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure);

    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

    Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null!);

    Task SignOutAsync();

    Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, bool lockoutOnFailure);

    AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null!);

    Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string userId = null!);

    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);

    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);

    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();

    Task<TUser?> GetTwoFactorAuthenticationUserAsync();

    Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);

    Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);

    Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user);

    Task RememberTwoFactorClientAsync(TUser user);

    Task<bool> IsTwoFactorClientRememberedAsync(TUser user);

    Task ForgetTwoFactorClientAsync();

    Task RefreshSignInAsync(TUser user);

    Task<bool> CanSignInAsync(TUser user);

    Task<TUser?> ValidateSecurityStampAsync(ClaimsPrincipal principal);

    Task<bool> ValidateSecurityStampAsync(TUser user, string securityStamp);

}
