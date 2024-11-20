namespace IdentitySystem.Domain;

public static class NotificationFactory
{
    public static Notification Create()
    {
        return new Notification();
    }

    public static Notification Create(string status, string message, string redirectUrl)
    {
        return new Notification()
        {
            Status = status,
            Message = message,
            RedirectUrl = redirectUrl
        };
    }

}