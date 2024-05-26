namespace IdentitySystem.Application;

public record NotificationDTO : DTOBase
{
    public string?  Status      { get; init; }
    public string?  Message     { get; init; }
    public string?  RedirectUrl { get; init; }
}
