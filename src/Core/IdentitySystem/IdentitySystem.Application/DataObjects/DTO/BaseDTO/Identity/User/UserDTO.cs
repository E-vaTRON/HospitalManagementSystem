namespace IdentitySystem.Application;

public record UserDTO : DTOBase
{
    public string           UserName                { get; init; } = string.Empty;
    public string           NormalizedUserName      { get; init; } = string.Empty;
    public string?          Email                   { get; init; }
    public string?          NormalizedEmail         { get; init; }
    public bool             EmailConfirmed          { get; init; }
    public string           PasswordHash            { get; init; } = string.Empty;
    public string?          SecurityStamp           { get; init; }
    public string?          ConcurrencyStamp        { get; init; }
    public string?          PhoneNumber             { get; init; }
    public bool             PhoneNumberConfirmed    { get; init; }
    public bool             TwoFactorEnabled        { get; init; }
    public DateTimeOffset?  LockoutEnd              { get; init; }
    public bool             LockoutEnabled          { get; init; }
    public int              AccessFailedCount       { get; init; }

    public string       FirstName       { get; init; } = string.Empty;
    public string       LastName        { get; init; } = string.Empty;
    public int          Age             { get; init; }
    public DateTime     DayOfBirth      { get; init; }
    public bool         Gender          { get; init; }
    public string       Address         { get; init; } = string.Empty;
    public string       CardID          { get; init; } = string.Empty;
    public int?         SpecialistLevel { get; init; }
    public bool         Verified        { get; init; }
}