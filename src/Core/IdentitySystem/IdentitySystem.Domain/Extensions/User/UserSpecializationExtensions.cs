namespace IdentitySystem.Domain;

public static class UserSpecializationExtensions
{
    #region [ Public Method ]
    public static UserSpecialization RemoveRelated(this UserSpecialization userSpecialization)
    {
        userSpecialization.User = null!;
        userSpecialization.Specialization = null!;
        return userSpecialization;
    }
    #endregion
}
