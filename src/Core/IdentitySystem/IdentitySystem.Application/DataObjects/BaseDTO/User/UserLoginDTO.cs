namespace IdentitySystem.Application;

public class UserLoginDTO : DTOBase
{
    public string?  LoginProvider       { get; set; }
    public string?  ProviderKey         { get; set; }
    public string?  ProviderDisplayName { get; set; }

    public UserDTO? User { get; set; }
}
