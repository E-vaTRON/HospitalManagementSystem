namespace HospitalManagementSystem.Application;

public record OutputImportationDTO : ImportationDTO
{
    public ICollection<OutputGoodSupplingDTO>? GoodSupplingDTOs { get; init; }
}
