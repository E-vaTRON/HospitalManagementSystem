namespace HospitalManagementSystem.Application;

public record AppointmentBaseDTO : DTOBase
{
    public DateTime AppointmentDate { get; init; } = default!;
    public string?  Notes           { get; init; }

    public string?  PatientId       { get; init; } // User Id Role<Patient>
}