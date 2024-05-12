namespace HospitalManagementSystem.Application;

public class DiseasesDTO : DTOBase
{
    public string       Name        { get; set; } = string.Empty;
    public string?      Description { get; set; }
    public CodeStatus   Status      { get; set; }

    public virtual ICollection<DiagnosisDTO> DiagnosesDTO { get; set; } = new HashSet<DiagnosisDTO>();
    public virtual ICollection<ICDCodeDTO>   ICDCodesDTO  { get; set; } = new HashSet<ICDCodeDTO>();
}