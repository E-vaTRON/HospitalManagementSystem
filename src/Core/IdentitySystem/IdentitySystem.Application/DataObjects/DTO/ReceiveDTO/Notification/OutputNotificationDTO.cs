namespace IdentitySystem.Application;

public record OutputNotificationDTO : NotificationDTO
{
    public UserDTO? UserDTO { get; init; }
}
