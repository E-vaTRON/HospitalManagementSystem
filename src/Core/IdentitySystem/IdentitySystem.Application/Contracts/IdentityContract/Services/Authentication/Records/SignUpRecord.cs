namespace IdentitySystem.Application;

public record SignUpRecord(string userName,
                     string password,
                     string firstName,
                     string lastName,
                     string? email,
                     string? phoneNumber,
                     string[]? roles
                     //File? avatarFile
                     );