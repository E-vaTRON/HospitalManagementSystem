namespace HospitalManagementSystem.Application;

public record OutputICDCodeDTO : ICDCodeDTO
{
    public DiseasesDTO? DiseasesDTO { get; init; }

    public ICollection<ICDCodeVersionDTO>? ICDCodeVersionDTOs { get; init; }
}
