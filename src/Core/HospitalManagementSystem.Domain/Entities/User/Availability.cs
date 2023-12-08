namespace HospitalManagementSystem.Domain;

public class Availability : EntityBase
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    public string? DoctorId { get; set; }
    public Doctor Doctor { get; set; } = default!;
}
