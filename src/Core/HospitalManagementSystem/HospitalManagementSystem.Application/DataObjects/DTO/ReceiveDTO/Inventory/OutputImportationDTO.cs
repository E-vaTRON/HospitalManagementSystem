namespace HospitalManagementSystem.Application;

public record OutputImportationDTO : ImportationDTO
{
    //public ICollection<OutputGoodSupplingDTO>? GoodSupplings { get; init; }

    public ICollection<DrugInventoryDTO>? DrugInventories { get; init; }
}
