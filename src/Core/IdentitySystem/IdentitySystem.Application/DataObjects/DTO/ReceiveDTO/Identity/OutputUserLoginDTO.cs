namespace IdentitySystem.Application;

public record OutputUserLoginDTO : UserLoginDTO
{
    public UserDTO? UserDTO { get; init; }
}
