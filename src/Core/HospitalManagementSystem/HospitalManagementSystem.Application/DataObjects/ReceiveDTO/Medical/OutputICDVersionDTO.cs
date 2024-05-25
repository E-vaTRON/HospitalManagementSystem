namespace HospitalManagementSystem.Application;

public record OutputICDVersionDTO : ICDVersionDTO
{
    public ICollection<ICDCodeVersionDTO>? ICDCodeVersionDTOs { get; set; }
}
