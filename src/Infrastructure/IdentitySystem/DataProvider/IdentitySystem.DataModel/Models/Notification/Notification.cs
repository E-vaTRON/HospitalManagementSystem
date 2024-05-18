namespace IdentitySystem.DataProvider;

public class Notification : ModelBase
{
    public string?  Status      { get; set; } // could be 'sent', 'not sent', etc.
    public string?  Message     { get; set; }
    public string?  RedirectUrl { get; set; }

    public Guid?    UserId  { get; set; }
    public User     User    { get; set; } = default!;
}