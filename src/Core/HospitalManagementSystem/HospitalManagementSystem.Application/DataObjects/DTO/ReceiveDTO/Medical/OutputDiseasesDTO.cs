namespace HospitalManagementSystem.Application;

public record OutputDiseasesDTO : DiseasesDTO
{
    public ICollection<DiagnosisDTO>?   DiagnosisDTOs   { get; init; }
    public ICollection<ICDCodeDTO>?     ICDCodesDTOs    { get; init; }
}