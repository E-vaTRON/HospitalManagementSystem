namespace IdentitySystem.Application;

public record UserTokenDTO : DTOBase
{
    public string?  LoginProvider   { get; init; }
    public string?  Name            { get; init; }
    public string?  Value           { get; init; }
}
