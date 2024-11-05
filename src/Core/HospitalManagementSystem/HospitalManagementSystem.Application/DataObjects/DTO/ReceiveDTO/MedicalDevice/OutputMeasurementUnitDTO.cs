namespace HospitalManagementSystem.Application;

public record OutputMeasurementUnitDTO : DTOBase
{
    public ICollection<OutputDeviceUnitDTO>? DeviceUnits { get; init; }
}
