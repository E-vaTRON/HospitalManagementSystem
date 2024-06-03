namespace HospitalManagementSystem.Application;

public record OutputDiseasesDTO : DiseasesDTO
{
    public ICollection<OutputDiagnosisDTO>?   DiagnosisDTOs   { get; init; }
    public ICollection<OutputICDCodeDTO>?     ICDCodesDTOs    { get; init; }
}