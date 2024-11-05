namespace HospitalManagementSystem.Application;

public record AssignmentHistoryDTO : DTOBase
{
    public AssignmentStatus     AssignmentStatus    { get; init; }

    public string?              DoctorId            { get; init; } // User Id Role<Doctor>
}
