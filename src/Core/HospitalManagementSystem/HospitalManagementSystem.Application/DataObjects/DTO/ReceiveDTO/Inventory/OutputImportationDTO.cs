namespace HospitalManagementSystem.Application;

public record OutputImportationDTO : ImportationDTO
{
    public ICollection<GoodSupplingDTO>? GoodSupplingDTOs { get; init; }
}
