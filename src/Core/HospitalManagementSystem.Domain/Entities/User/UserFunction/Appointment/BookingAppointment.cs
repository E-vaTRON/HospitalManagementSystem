namespace HospitalManagementSystem.Domain;

public class BookingAppointment : AppointmentBase
{
    public string?      MedicalExamId   { get; set; }
    public MedicalExam? MedicalExam     { get; set; }
}
