namespace IdentitySystem.Domain;

public static class UserExtensions
{
    #region [ Private Methods ]
    private static User AddUserRole(this User user, Role role, UserRole userRole)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userRole));

        if (user.UserRoles.Any(x => x.Id == userRole.Id))
        {
            return user;
        }

        userRole.UserId = user.Id;
        userRole.RoleId = role.Id;
        role.UserRoles.Add(userRole);
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
        user.UserLogins.Add(userLogin);
        return user;
    }

    private static User AddUserSpecialization(this User user, Specialization specialization, UserSpecialization userSpecialization)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(userSpecialization));

        if (user.UserSpecializations.Any(x => x.Id == userSpecialization.Id))
        {
            return user;
        }

        userSpecialization.UserId = user.Id;
        userSpecialization.SpecializationId = specialization.Id;
        specialization.UserSpecializations.Add(userSpecialization);
        user.UserSpecializations.Add(userSpecialization);
        return user;
    }
    #endregion

    #region [ Public Methods ]
    public static User AddUserRole(this User user, Role role)
    {
        return user.AddUserRole(role, UserRoleFactory.Create());
    }

    public static User AddUserToken(this User user, string loginProvider, string name, string value)
    {
        return user.AddUserToken(UserTokenFactory.Create(loginProvider, name, value));
    }

    public static User AddUserClaim(this User user, int id, string claimType, string claimValue)
    {
        return user.AddUserClaim(UserClaimFactory.Create(id, claimType, claimValue));
    }

    public static User AddUserLogin(this User user)
    {
        return user.AddUserLogin(UserLoginFactory.Create());
    }

    public static User AddUserLogin(this User user, string loginProvider, string providerDisplayName)
    {
        return user.AddUserLogin(UserLoginFactory.Create(loginProvider, loginProvider + user.Id + user.UserName, providerDisplayName));
    }

    public static User AddUserSpecialization(this User user, Specialization specialization)
    {
        return user.AddUserSpecialization(specialization, UserSpecializationFactory.Create());
    }
    #endregion
}
