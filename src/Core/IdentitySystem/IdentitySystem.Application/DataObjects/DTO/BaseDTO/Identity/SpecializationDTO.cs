namespace IdentitySystem.Application;

public record SpecializationDTO : DTOBase
{
    public string   Name        { get; init; } = string.Empty;
    public string?  Description { get; init; }
}
