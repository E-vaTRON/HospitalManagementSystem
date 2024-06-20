namespace IdentitySystem.Domain;

public static class UserExtensions
{
    #region [ Private Methods ]
    private static User AddPasswordHash(this User user, string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(password));

        // Create salt
        byte[] salt = new byte[16];
        RandomNumberGenerator.Fill(salt);

        // Create hash
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        // Combine salt and hash
        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        // Convert to base64 string
        user.PasswordHash = Convert.ToBase64String(hashBytes);
        return user;
    }

    private static User AddUserRole(this User user, UserRole userRole)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userRole));

        if (user.UserRoles.Any(x => x.Id == userRole.Id))
        {
            return user;
        }

        userRole.UserId = user.Id;
        userRole.User = user;
        user.UserRoles.Add(userRole);
        return user;
    }

    private static User AddUserToken(this User user, UserToken userToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userToken));

        if (user.UserTokens.Any(x => x.Id == userToken.Id))
        {
            return user;
        }

        userToken.UserId = user.Id;
        userToken.User = user;
        user.UserTokens.Add(userToken);
        return user;
    }

    private static User AddUserClaim(this User user, UserClaim userClaim)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userClaim));

        if (user.UserClaims.Any(x => x.Id == userClaim.Id))
        {
            return user;
        }

        userClaim.UserId = user.Id;
        userClaim.User = user;
        user.UserClaims.Add(userClaim);
        return user;
    }

    private static User AddUserLogin(this User user, UserLogin userLogin)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userLogin));


        if (user.UserLogins.Any(x => x.Id == userLogin.Id))
        {
            return user;
        }

        userLogin.UserId = user.Id;
        userLogin.User = user;
        user.UserLogins.Add(userLogin);
        return user;
    }

    private static User AddUserSpecialization(this User user, UserSpecialization userSpecialization)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userSpecialization));

        if (user.UserSpecializations.Any(x => x.Id == userSpecialization.Id))
        {
            return user;
        }

        userSpecialization.UserId = user.Id;
        userSpecialization.User = user;
        user.UserSpecializations.Add(userSpecialization);
        return user;
    }
    #endregion

    #region [ Public Methods ]
    public static User AddPassword(this User user, string password)
    {
        return user.AddPasswordHash(password);
    }

    public static User AddUserRole(this User user)
    {
        var newUserRole = UserRoleFactory.Create();
        return user;
    }

    public static User AddUserRole(this User user, string userId, string roleId)
    {
        var newUserRole = UserRoleFactory.Create(userId, roleId);
        return user;
    }

    public static User AddUserToken(this User user)
    {
        var newUserToken = UserTokenFactory.Create();
        return user;
    }

    public static User AddUserToken(this User user, string loginProvider, string name, string value)
    {
        var newUserToken = UserTokenFactory.Create(loginProvider, name, value, user.Id.ToString());
        return user;
    }

    public static User AddUserClaim(this User user)
    {
        var newUserClaim = UserClaimFactory.Create();
        return user;
    }

    public static User AddUserClaim(this User user, string claimType, string claimValue)
    {
        var newUserClaim = UserClaimFactory.Create(user.Id.ToString(), claimType, claimValue);
        return user;
    }

    public static User AddUserLogin(this User user)
    {
        var newUserLogin = UserLoginFactory.Create();
        return user;
    }

    public static User AddUserLogin(this User user, string loginProvider, string providerKey, string providerDisplayName)
    {
        var newUserLogin = UserLoginFactory.Create(loginProvider, providerKey, providerDisplayName, user.Id.ToString());
        return user;
    }

    public static User AddUserSpecialization(this User user)
    {
        var newUserSpecialization = UserSpecializationFactory.Create();
        return user;
    }

    public static User AddUserSpecialization(this User user, string specializationId)
    {
        var newUserSpecialization = UserSpecializationFactory.Create(user.Id.ToString(), specializationId);
        return user;
    }

    

    #endregion
}
