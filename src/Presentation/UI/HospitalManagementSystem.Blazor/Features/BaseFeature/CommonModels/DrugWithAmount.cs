namespace HospitalManagementSystem.Blazor;

public record DrugWithAmount : OutputDrugDTO
{
    public int Amount { get; set; }
}