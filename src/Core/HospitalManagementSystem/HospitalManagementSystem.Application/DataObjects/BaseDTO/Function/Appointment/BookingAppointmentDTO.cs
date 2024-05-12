namespace HospitalManagementSystem.Application;

public class BookingAppointmentDTO : AppointmentBaseDTO
{
    public string?          DoctorDTOId     { get; set; } // User Id Role<Doctor>

    public MedicalExamDTO?  MedicalExamDTO  { get; set; }
}
