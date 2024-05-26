namespace HospitalManagementSystem.Application;

public record OutputDrugDTO : DrugDTO
{
    public ICollection<GoodSupplingDTO>? GoodSupplingDTOs { get; init; }
}