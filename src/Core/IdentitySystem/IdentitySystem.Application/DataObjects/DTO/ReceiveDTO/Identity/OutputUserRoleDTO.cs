namespace IdentitySystem.Application;

public record OutputUserRoleDTO : UserRoleDTO
{
    public UserDTO? UserDTO { get; init; }
    public RoleDTO? RoleDTO { get; init; }
}
