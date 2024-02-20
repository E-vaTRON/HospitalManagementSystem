namespace HospitalManagementSystem.DataBaseContextProvider;

public class Appointment : ModelBase
{
    public DateTime     AppointmentDate     { get; set; } = default!;
    public string?      Notes               { get; set; }

    public string?          PatientId       { get; set; }
    public Patient          Patient         { get; set; } = default!;
    public string?          DoctorId        { get; set; }
    public Doctor           Doctor          { get; set; } = default!;
    public string?          MedicalExamId   { get; set; }
    public MedicalExam?     MedicalExam     { get; set; }
}