namespace IdentitySystem.Domain;

public class UserSpecializationFactory
{
    public static UserSpecialization Create()
    {
        return new UserSpecialization();
    }

    public static UserSpecialization Create(string userId, string specializationId)
    {
        return new UserSpecialization()
        {
            UserId = userId,
            SpecializationId = specializationId
        };
    }
}
