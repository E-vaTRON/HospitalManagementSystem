namespace HospitalManagementSystem.Application;

public class ICDCodeDTO : DTOBase
{
    public string?      Code         { get; set; }

    public DiseasesDTO     DiseasesDTO    { get; set; } = default!;

    public virtual ICollection<ICDCodeVersionDTO> ICDCodeVersionDTOs { get; set; } = new HashSet<ICDCodeVersionDTO>();
}
