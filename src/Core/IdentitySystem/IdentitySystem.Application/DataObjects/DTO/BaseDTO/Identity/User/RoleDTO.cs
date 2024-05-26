namespace IdentitySystem.Application;

public record RoleDTO : DTOBase
{
    public string Name              { get; init; } = string.Empty;
    public string NormalizedName    { get; init; } = string.Empty;
    public string ConcurrencyStamp  { get; init; } = string.Empty;
}
