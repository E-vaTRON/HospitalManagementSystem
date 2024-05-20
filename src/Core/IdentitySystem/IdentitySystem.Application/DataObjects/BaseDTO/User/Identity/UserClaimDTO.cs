namespace IdentitySystem.Application;

public class UserClaimDTO : DTOIntBase
{
    public string?  ClaimType   { get; set; }
    public string?  ClaimValue  { get; set; }

    public UserDTO? User { get; set; }
}
