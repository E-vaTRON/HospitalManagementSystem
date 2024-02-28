namespace HospitalManagementSystem.Domain;

public class AppointmentBase : EntityBase
{
    public DateTime     AppointmentDate { get; set; } = default!;
    public string?      Notes           { get; set; }

    public string?      PatientId       { get; set; }
    public Patient      Patient         { get; set; } = default!;
    public string?      DoctorId        { get; set; }
    public Doctor       Doctor          { get; set; } = default!;
}