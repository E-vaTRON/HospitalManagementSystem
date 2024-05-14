namespace IdentitySystem.Application;

public class SpecializationDTO : DTOBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }
    public ICollection<UserDTO> UserDTOs { get; set; } = new HashSet<UserDTO>();
}
