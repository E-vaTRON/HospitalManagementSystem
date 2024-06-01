namespace HospitalManagementSystem.Application;

public record OutputICDCodeDTO : ICDCodeDTO
{
    public OutputDiseasesDTO? DiseasesDTO { get; init; }

    public ICollection<OutputICDCodeVersionDTO>? ICDCodeVersionDTOs { get; init; }
}
