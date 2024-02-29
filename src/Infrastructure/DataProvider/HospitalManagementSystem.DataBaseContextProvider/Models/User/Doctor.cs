namespace HospitalManagementSystem.DataProvider;

public class Doctor : Employee
{
    public int? SpecialistLevel { get; set; }

    public virtual ICollection<MedicalExamEposode> ExamEposodes         { get; set; } = new HashSet<MedicalExamEposode>();
    public virtual ICollection<Referral>            Referrals           { get; set; } = new HashSet<Referral>();
    public virtual ICollection<BookingAppointment>  BookingAppointments { get; set; } = new HashSet<BookingAppointment>();
}