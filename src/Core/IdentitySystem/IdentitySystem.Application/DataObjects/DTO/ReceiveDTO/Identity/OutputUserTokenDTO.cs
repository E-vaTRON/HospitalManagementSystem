namespace IdentitySystem.Application;

public record OutputUserTokenDTO : UserTokenDTO
{
    public UserDTO? UserDTO { get; init; }
}