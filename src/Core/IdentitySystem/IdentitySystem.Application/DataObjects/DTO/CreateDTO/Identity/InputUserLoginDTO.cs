namespace IdentitySystem.Application;

public record InputUserLoginDTO : UserLoginDTO
{
    public string? UserDTOId { get; init; }
}
