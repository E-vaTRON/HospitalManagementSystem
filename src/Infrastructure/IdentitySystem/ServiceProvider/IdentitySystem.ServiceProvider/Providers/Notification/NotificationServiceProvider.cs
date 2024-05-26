using CoreNotification = IdentitySystem.Domain.Notification;
using DTONotificationIn = IdentitySystem.Application.InputNotificationDTO;
using DTONotificationOut = IdentitySystem.Application.OutputNotificationDTO;

namespace IdentitySystem.ServiceProvider;

public class NotificationServiceProvider : ServiceProviderBase<DTONotificationOut, DTONotificationIn, CoreNotification>, INotificationServiceProvider
{
    public NotificationServiceProvider(INotificationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
