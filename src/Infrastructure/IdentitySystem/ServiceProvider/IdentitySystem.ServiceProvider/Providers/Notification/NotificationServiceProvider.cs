using CoreNotification = IdentitySystem.Domain.Notification;
using DataNotification = IdentitySystem.DataProvider.Notification;

namespace IdentitySystem.ServiceProvider;

public class NotificationServiceProvider : ServiceProviderBase<CoreNotification>, INotificationServiceProvider
{
    public NotificationServiceProvider(INotificationDataProvider dataProvider) : base(dataProvider)
    {
    }
}
