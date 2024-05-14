namespace IdentitySystem.Application;

public class RoleDTO : DTOBase
{
    public string Name              { get; set; } = string.Empty;
    public string NormalizedName    { get; set; } = string.Empty;
    public string ConcurrencyStamp  { get; set; } = string.Empty;

    public virtual ICollection<UserRoleDTO> UserRoleDTOs { get; set; } = new HashSet<UserRoleDTO>();
}
