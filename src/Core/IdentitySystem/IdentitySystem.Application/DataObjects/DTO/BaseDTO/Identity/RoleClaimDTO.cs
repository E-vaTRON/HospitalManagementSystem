namespace IdentitySystem.Application;

public record RoleClaimDTO : DTOIntBase
{
    public string?  ClaimType   { get; init; }
    public string?  ClaimValue  { get; init; }
}
