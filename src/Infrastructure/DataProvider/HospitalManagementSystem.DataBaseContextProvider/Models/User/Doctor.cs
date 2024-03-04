namespace HospitalManagementSystem.DataProvider;

public class Doctor : Employee
{
    public int? SpecialistLevel { get; set; }

    public virtual ICollection<MedicalExamAssignment>   MedicalExamAssignments  { get; set; } = new HashSet<MedicalExamAssignment>();
    public virtual ICollection<BookingAppointment>      BookingAppointments     { get; set; } = new HashSet<BookingAppointment>();
}