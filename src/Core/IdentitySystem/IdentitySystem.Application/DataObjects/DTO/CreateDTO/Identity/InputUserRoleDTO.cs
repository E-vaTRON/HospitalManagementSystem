namespace IdentitySystem.Application;

public record InputUserRoleDTO : UserRoleDTO
{
    public string? UserDTOId { get; init; }
    public string? RoleDTOId { get; init; }
}