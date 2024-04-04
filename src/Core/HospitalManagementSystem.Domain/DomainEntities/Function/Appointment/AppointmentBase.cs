namespace HospitalManagementSystem.Domain;

public class AppointmentBase : EntityBase
{
    public DateTime AppointmentDate { get; set; } = default!;
    public string?  Notes           { get; set; }

    public string?  PatientId       { get; set; } // User Id Role<Patient>
}