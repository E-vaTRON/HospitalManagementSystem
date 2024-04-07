namespace HospitalManagementSystem.DataProvider;

public class BookingAppointment : AppointmentBase
{
    public string?      DoctorId        { get; set; } // User Id Role<Doctor>

    public MedicalExam? MedicalExam     { get; set; } // This is Principal Table
}
