namespace IdentitySystem.Application;

public record InputUserSpecializationDTO : UserSpecializationDTO
{
    public string? UserDTOId            { get; init; }
    public string? SpecializationDTOId  { get; init; }
}
