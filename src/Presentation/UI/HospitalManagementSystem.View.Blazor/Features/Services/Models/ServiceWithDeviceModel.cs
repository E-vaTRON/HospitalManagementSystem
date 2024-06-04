namespace HospitalManagementSystem.Blazor;

public record ServiceWithDeviceModel : InputServiceDTO
{
    public ICollection<DeviceInventoryDTO>? DevicesServiceAvailable { get; set; }

    public bool IsServiceNameValid { get; set; }
    public bool IsNameNotDuplicated { get; set; }
    public bool IsPriceValid { get; set; }
}
