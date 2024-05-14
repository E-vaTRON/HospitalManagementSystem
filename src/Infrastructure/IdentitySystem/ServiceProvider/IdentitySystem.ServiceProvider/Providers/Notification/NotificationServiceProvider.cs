using CoreNotification = IdentitySystem.Domain.Notification;
using DTONotification = IdentitySystem.Application.NotificationDTO;

namespace IdentitySystem.ServiceProvider;

public class NotificationServiceProvider : ServiceProviderBase<DTONotification, CoreNotification>, INotificationServiceProvider
{
    public NotificationServiceProvider(INotificationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
