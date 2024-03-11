namespace HospitalManagementSystem.Domain;

public class Doctor : Employee
{
    public int? SpecialistLevel { get; set; }

    public virtual ICollection<AssignmentHistory>   AssignmentHistories  { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<BookingAppointment>  BookingAppointments { get; set; } = new HashSet<BookingAppointment>();
}