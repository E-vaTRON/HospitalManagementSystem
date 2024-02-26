namespace HospitalManagementSystem.DataProvider;

public class Doctor : Employee
{
    public int?     SpecialistLevel     { get; set; }

    public virtual ICollection<Appointment>         Appointments    { get; set; } = new HashSet<Appointment>();
    public virtual ICollection<MedicalExamEposode>  Exams           { get; set; } = new HashSet<MedicalExamEposode>();
    public virtual ICollection<Referral>            Referrals       { get; set; } = new HashSet<Referral>();
}