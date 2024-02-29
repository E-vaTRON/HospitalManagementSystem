namespace HospitalManagementSystem.Domain;

public class Doctor : Employee
{
    public int?     SpecialistLevel     { get; set; }

    public virtual ICollection<MedicalExamEposode>  Exams               { get; set; } = new HashSet<MedicalExamEposode>();
    public virtual ICollection<Referral>            Referrals           { get; set; } = new HashSet<Referral>();
    public virtual ICollection<ReExamAppointment>   ReExamAppointments  { get; set; } = new HashSet<ReExamAppointment>();
    public virtual ICollection<BookingAppointment>  BookingAppointments { get; set; } = new HashSet<BookingAppointment>();
}