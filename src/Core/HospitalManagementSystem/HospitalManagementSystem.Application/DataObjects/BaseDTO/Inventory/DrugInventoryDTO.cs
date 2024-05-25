namespace HospitalManagementSystem.Application;

public record DrugInventoryDTO : DTOBase
{
    public int  CurrentAmount   { get; init; }       //số lượng hiện tại
}
