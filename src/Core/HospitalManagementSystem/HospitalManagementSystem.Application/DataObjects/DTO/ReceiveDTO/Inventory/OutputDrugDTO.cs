namespace HospitalManagementSystem.Application;

public record OutputDrugDTO : DrugDTO
{
    public ICollection<OutputGoodSupplingDTO>? GoodSupplingDTOs { get; init; }
}