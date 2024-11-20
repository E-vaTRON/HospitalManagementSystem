namespace IdentitySystem.Domain;

public static class SpecializationExtensions
{
    #region [ Public Method ]
    public static Specialization RemoveRelated(this Specialization specialization)
    {
        specialization.UserSpecializations.Clear();
        return specialization;
    }
    #endregion
}
