namespace HospitalManagementSystem.Application;

public record DiseasesDTO : DTOBase
{
    public string       Name        { get; init; } = string.Empty;
    public string?      Description { get; init; }
    public CodeStatus   Status      { get; init; }

    public virtual ICollection<DiagnosisDTO> DiagnosesDTO { get; init; } = new HashSet<DiagnosisDTO>();
    public virtual ICollection<ICDCodeDTO>   ICDCodesDTO  { get; init; } = new HashSet<ICDCodeDTO>();
}