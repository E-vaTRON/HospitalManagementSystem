namespace IdentitySystem.Application;

public record InputNotificationDTO : NotificationDTO
{
    public string? UserDTOId { get; init; }
}