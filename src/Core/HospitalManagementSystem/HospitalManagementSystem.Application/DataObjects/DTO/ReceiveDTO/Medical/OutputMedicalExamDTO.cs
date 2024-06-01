namespace HospitalManagementSystem.Application;

public record OutputMedicalExamDTO : MedicalExamDTO
{
    public OutputBookingAppointmentDTO? BookingAppointmentDTO   { get; init; }

    public ICollection<OutputMedicalExamEpisodeDTO>?  MedicalExamEpisodeDTOs  { get; init; }
    public ICollection<OutputReferralDTO>?            ReferralDTOs            { get; init; }
}