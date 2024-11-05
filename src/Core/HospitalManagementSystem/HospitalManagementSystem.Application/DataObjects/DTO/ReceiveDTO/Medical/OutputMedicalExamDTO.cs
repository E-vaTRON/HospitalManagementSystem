namespace HospitalManagementSystem.Application;

public record OutputMedicalExamDTO : MedicalExamDTO
{
    public OutputBookingAppointmentDTO? BookingAppointment   { get; init; }

    public ICollection<OutputMedicalExamEpisodeDTO>?  MedicalExamEpisodes  { get; init; }
    public ICollection<OutputReferralDTO>?            Referrals            { get; init; }
}