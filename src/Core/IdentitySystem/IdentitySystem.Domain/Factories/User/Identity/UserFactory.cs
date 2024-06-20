namespace IdentitySystem.Domain;

public static class UserFactory
{
    public static User Create()
    {
        return new User();
    }

    public static User Create(string userName, string email, string firstName, string lastName, int age, 
        DateTime dayOfBirth, bool gender, string cardID, int? specialistLevel, DateTime? lastUpdatedOn)
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

    public static User Create(string userName, string normalizedUserName, 
                              string email, string normalizedEmail, bool emailConfirmed,
                              string securityStamp, string concurrencyStamp, 
                              string phoneNumber, bool phoneNumberConfirmed, 
                              bool twoFactorEnabled, bool lockoutEnabled, int accessFailedCount, 
        string firstName, string lastName, int age, bool gender, string address, 
        string cardID, int? specialistLevel, bool verified)
    {
        return new User()
        {
            UserName = userName,
            NormalizedUserName = normalizedUserName,
            Email = email,
            NormalizedEmail = normalizedEmail,
            EmailConfirmed = emailConfirmed,
            SecurityStamp = securityStamp,
            ConcurrencyStamp = concurrencyStamp,
            PhoneNumber = phoneNumber,
            PhoneNumberConfirmed = phoneNumberConfirmed,
            TwoFactorEnabled = twoFactorEnabled,
            LockoutEnabled = lockoutEnabled,
            AccessFailedCount = accessFailedCount,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Gender = gender,
            Address = address,
            CardID = cardID,
            SpecialistLevel = specialistLevel,
            Verified = verified
        };
    }
}