namespace HospitalManagementSystem.DataProvider;

public class BookingAppointment : AppointmentBase
{
    public string?      DoctorId        { get; set; } // User Id Role<Doctor>

    public string?      MedicalExamId   { get; set; }
    public MedicalExam? MedicalExam     { get; set; }
}
