namespace IdentitySystem.Application;

public record InputUserClaimDTO : UserClaimDTO
{
    public string? UserDTOId { get; init; }
}
