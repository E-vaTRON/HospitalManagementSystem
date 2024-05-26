namespace IdentitySystem.Application;

public record InputRoleClaimDTO : RoleClaimDTO
{
    public string? RoleDTOId { get; init; }
}
