namespace HospitalManagementSystem.Application;

public record OutputICDCodeDTO : ICDCodeDTO
{
    public DiseasesDTO? DiseasesDTO { get; set; }

    public ICollection<ICDCodeVersionDTO>? ICDCodeVersionDTOs { get; set; }
}
