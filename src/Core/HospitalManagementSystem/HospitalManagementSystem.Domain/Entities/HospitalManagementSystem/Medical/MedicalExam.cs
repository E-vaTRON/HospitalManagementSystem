namespace HospitalManagementSystem.Domain;

public class MedicalExam : EntityBase
{
    public int? FinalPrice { get; set; }

    public string?              BookingAppointmentId    { get; set; }
    public BookingAppointment?  BookingAppointment      { get; set; } = default!;

    public virtual ICollection<MedicalExamEpisode>  MedicalExamEpisodes { get; set; } = new HashSet<MedicalExamEpisode>();
    public virtual ICollection<Referral>            Referrals           { get; set; } = new HashSet<Referral>();
}