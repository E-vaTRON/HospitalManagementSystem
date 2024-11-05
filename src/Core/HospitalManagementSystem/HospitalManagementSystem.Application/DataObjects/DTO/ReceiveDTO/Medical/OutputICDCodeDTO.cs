namespace HospitalManagementSystem.Application;

public record OutputICDCodeDTO : ICDCodeDTO
{
    public OutputDiseasesDTO? Diseases { get; init; }

    public ICollection<OutputICDCodeVersionDTO>? ICDCodeVersions { get; init; }
}
