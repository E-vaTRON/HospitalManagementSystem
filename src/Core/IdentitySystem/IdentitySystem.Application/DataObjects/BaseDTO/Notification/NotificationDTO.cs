namespace IdentitySystem.Application;

public class NotificationDTO : DTOBase
{
    public string?  Status      { get; set; }
    public string?  Message     { get; set; }
    public string?  RedirectUrl { get; set; }

    public UserDTO?     UserDTO { get; set; }
}
