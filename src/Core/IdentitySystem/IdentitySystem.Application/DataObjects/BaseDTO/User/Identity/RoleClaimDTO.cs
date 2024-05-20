namespace IdentitySystem.Application;

public class RoleClaimDTO : DTOIntBase
{
    public string? ClaimType    { get; set; }
    public string? ClaimValue   { get; set; }

    public RoleDTO? RoleDTO { get; set; }
}
