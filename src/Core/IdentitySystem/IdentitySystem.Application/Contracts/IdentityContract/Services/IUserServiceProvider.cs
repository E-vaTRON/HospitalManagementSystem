namespace IdentitySystem.Application;

public interface IUserServiceProvider : IUserContractBase<UserDTO, string>
{
    Task<SignInResult> CheckPasswordSignInAsync(UserDTO user, string password, LoginMode mode, bool lockoutOnFailure);
}
