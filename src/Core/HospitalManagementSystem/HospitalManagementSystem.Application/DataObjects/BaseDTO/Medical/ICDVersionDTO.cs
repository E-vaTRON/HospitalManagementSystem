namespace HospitalManagementSystem.Application;

public class ICDVersionDTO : DTOBase
{
    public string? Version { get; set; }
    public virtual ICollection<ICDCodeVersionDTO> ICDCodeVersionDTOs { get; set; } = new HashSet<ICDCodeVersionDTO>();
}
