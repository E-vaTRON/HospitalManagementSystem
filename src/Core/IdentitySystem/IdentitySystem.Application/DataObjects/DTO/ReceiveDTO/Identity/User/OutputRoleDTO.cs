namespace IdentitySystem.Application;

public record OutputRoleDTO : RoleDTO
{
    public ICollection<UserRoleDTO>? UserRoleDTOs { get; init; }
}