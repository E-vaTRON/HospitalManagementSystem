namespace IdentitySystem.Application;

public record OutputRoleClaimDTO : RoleClaimDTO
{
    public RoleDTO? RoleDTO { get; init; }
}
