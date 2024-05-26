namespace HospitalManagementSystem.Application;

public record DeviceInventoryDTO : DTOBase
{
    public int CurrentAmount { get; init; }       //số lượng hiện tại
}
