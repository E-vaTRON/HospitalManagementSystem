namespace IdentitySystem.Domain;

public static class UserFactory
{
    public static User Create()
    {
        return new User();
    }

    public static User Create(string userName, string email, string firstName, string lastName, int age, DateTime dayOfBirth, bool gender, string address, string cardID, int? specialistLevel, bool verified, bool isDeleted, bool isExpired, DateTime createdOn, DateTime? lastUpdatedOn, DateTime? deleteOn)
    {
        return new User()
        {
            UserName = userName,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            DayOfBirth = dayOfBirth,
            Gender = gender,
            Address = address,
            CardID = cardID,
            SpecialistLevel = specialistLevel,
            Verified = verified,
            IsDeleted = isDeleted,
            IsExpired = isExpired,
            CreatedOn = createdOn,
            LastUpdatedOn = lastUpdatedOn,
            DeleteOn = deleteOn
        };
    }

    public static User Create(string userName, string email, string firstName, string lastName, int age, DateTime dayOfBirth, bool gender, string cardID, int? specialistLevel, DateTime? lastUpdatedOn)
    {
        return new User()
        {
            UserName = userName,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            DayOfBirth = dayOfBirth,
            Gender = gender,
            Address = string.Empty,
            CardID = cardID,
            SpecialistLevel = specialistLevel,
            Verified = false,
            IsDeleted = false,
            IsExpired = false,
            CreatedOn = DateTime.UtcNow,
            LastUpdatedOn = lastUpdatedOn
        };
    }


}