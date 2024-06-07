using System.Security.Cryptography;
using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class UserPasswordHasher
{
    public string HashPassword(CoreUser user, string password)
    {
        throw new NotImplementedException();
    }

    public PasswordVerificationResult VerifyHashedPassword(CoreUser user, string hashedPassword, string providedPassword)
    {
        throw new NotImplementedException();
    }
}
