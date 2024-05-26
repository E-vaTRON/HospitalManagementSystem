namespace IdentitySystem.Application;

public record UserClaimDTO : DTOIntBase
{
    public string?  ClaimType   { get; init; }
    public string?  ClaimValue  { get; init; }
}
