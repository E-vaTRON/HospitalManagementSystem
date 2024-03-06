using HospitalManagementSystem.Context.Models.Function.Appointment;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExam : ModelBase
{
    public string?              BookingAppointmentId    { get; set; }
    public BookingAppointment?  BookingAppointment      { get; set; } = default!;

    public virtual ICollection<MedicalExamEposode>  MedicalExamEposodes { get; set; } = new HashSet<MedicalExamEposode>();
    public virtual ICollection<Referral>            Referrals           { get; set; } = new HashSet<Referral>();
}