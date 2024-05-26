namespace IdentitySystem.Application;

public record InputUserTokenDTO : UserTokenDTO
{
    public string? UserDTOId { get; init; }
}
