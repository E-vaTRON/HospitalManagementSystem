namespace IdentitySystem.Application;

public class UserRoleDTO : DTOBase
{
    public virtual UserDTO?     UserDTO { get; set; }
    public virtual RoleDTO?     RoleDTO { get; set; }
}
