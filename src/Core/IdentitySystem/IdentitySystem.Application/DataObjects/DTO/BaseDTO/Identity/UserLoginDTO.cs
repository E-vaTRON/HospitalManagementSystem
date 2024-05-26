namespace IdentitySystem.Application;

public record UserLoginDTO : DTOBase
{
    public string?  LoginProvider       { get; init; }
    public string?  ProviderKey         { get; init; }
    public string?  ProviderDisplayName { get; init; }
}
