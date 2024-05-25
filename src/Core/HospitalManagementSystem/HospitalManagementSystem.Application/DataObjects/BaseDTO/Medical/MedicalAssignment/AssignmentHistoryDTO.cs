namespace HospitalManagementSystem.Application;

public record AssignmentHistoryDTO : DTOBase
{
    public string? AssignmentStatus { get; init; }

    public string?  DoctorId    { get; init; } // User Id Role<Doctor>
}
