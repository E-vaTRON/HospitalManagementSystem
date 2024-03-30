namespace HospitalManagementSystem.DataProvider;

public class AppointmentBase : ModelBase
{
    public DateTime AppointmentDate { get; set; } = default!;
    public string? Notes { get; set; }
}