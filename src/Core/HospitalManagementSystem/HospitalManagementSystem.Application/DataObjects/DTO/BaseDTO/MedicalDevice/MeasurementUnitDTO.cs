namespace HospitalManagementSystem.Application;

public record MeasurementUnitDTO : DTOBase
{
    public string? Name     { get; init; }
    public string? Symbol   { get; init; }
}
