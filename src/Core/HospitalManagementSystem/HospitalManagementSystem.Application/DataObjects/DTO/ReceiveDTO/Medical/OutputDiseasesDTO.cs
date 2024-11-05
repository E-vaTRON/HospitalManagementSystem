namespace HospitalManagementSystem.Application;

public record OutputDiseasesDTO : DiseasesDTO
{
    public ICollection<OutputDiagnosisDTO>?   Diagnosis   { get; init; }
    public ICollection<OutputICDCodeDTO>?     ICDCodes    { get; init; }
}