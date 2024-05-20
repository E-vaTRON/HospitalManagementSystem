namespace IdentitySystem.Application;

public class UserSpecializationDTO : DTOBase
{
    public UserDTO?             UserDTO           { get; set; }
    public SpecializationDTO?   SpecializationDTO { get; set; }
}
