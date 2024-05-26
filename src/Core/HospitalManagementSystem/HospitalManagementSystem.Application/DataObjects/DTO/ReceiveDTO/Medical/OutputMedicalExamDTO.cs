namespace HospitalManagementSystem.Application;

public record OutputMedicalExamDTO : MedicalExamDTO
{
    public BookingAppointmentDTO? BookingAppointmentDTO   { get; init; }

    public ICollection<MedicalExamEpisodeDTO>?  MedicalExamEpisodeDTOs  { get; init; }
    public ICollection<ReferralDTO>?            ReferralDTOs            { get; init; }
}