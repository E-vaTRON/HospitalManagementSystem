using CoreNotification = IdentitySystem.Domain.Notification;
using DataNotification = IdentitySystem.DataProvider.Notification;

namespace IdentitySystem.DataProvider;

public class NotificationDataProvider : DataProviderBase<CoreNotification, DataNotification>, INotificationDataProvider
{
    public NotificationDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
