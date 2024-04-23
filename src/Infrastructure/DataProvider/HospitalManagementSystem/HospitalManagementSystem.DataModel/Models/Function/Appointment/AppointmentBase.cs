namespace HospitalManagementSystem.DataProvider;

public class AppointmentBase : ModelBase
{
    public DateTime AppointmentDate { get; set; } = default!;
    public string?  Notes           { get; set; }

    public string?  PatientId       { get; set; } // User Id Role<Patient>
}