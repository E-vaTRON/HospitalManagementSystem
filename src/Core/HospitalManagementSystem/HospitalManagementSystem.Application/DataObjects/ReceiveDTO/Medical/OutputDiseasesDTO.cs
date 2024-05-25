namespace HospitalManagementSystem.Application;

public record OutputDiseasesDTO : DiseasesDTO
{
    public ICollection<DiagnosisDTO>?   DiagnosisDTOs   { get; set; }
    public ICollection<ICDCodeDTO>?     ICDCodesDTOs    { get; set; }
}