namespace IdentitySystem.Application;

public interface IUserServiceProvider : IUserManagerProvider<UserDTO, string>
{
    Task<SignInResult> CheckPasswordSignInAsync(UserDTO user, string password, LoginMode mode, bool lockoutOnFailure, CancellationToken cancellationToken = default!);
}
