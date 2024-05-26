namespace IdentitySystem.Application;

public record OutputUserClaimDTO : UserClaimDTO
{
    public UserDTO? UserDTO { get; init; }
}