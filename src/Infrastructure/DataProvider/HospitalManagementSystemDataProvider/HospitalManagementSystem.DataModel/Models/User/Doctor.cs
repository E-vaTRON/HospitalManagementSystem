namespace HospitalManagementSystem.DataProvider;

public class Doctor : Employee
{
    public int? SpecialistLevel { get; set; }

    public virtual ICollection<AssignmentHistory>   AssignmentHistories { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<ReferralDoctor>      ReferralDoctors     { get; set; } = new HashSet<ReferralDoctor>();
    public virtual ICollection<BookingAppointment>  BookingAppointments { get; set; } = new HashSet<BookingAppointment>();
}