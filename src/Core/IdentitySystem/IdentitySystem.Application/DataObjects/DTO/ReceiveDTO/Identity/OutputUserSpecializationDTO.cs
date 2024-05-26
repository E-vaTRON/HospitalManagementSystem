namespace IdentitySystem.Application;

public record OutputUserSpecializationDTO : UserSpecializationDTO
{
    public UserDTO?             UserDTO             { get; init; }
    public SpecializationDTO?   SpecializationDTO   { get; init; }
}