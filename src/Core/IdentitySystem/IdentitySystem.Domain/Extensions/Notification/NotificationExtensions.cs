namespace IdentitySystem.Domain;

public static class NotificationExtensions
{
    #region [ Public Method ]
    public static Notification RemoveRelated(this Notification notification)
    {
        notification.User = null!;
        return notification;
    }
    #endregion
}
