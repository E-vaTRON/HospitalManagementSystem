namespace IdentitySystem.Application;

public record OutputSpecializationDTO : SpecializationDTO
{
    public ICollection<UserDTO>? UserDTOs { get; init; }
}
