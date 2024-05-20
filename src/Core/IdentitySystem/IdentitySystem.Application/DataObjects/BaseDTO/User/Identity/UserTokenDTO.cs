namespace IdentitySystem.Application;

public class UserTokenDTO : DTOBase
{
    public string?  LoginProvider   { get; set; }
    public string?  Name            { get; set; }
    public string?  Value           { get; set; }

    public UserDTO? UserDTO { get; set; }
}
