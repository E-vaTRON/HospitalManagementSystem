namespace HospitalManagementSystem.Application;

public record OutputMedicalExamDTO : MedicalExamDTO
{
    public BookingAppointmentDTO? BookingAppointmentDTO   { get; set; }

    public ICollection<MedicalExamEpisodeDTO>?  MedicalExamEpisodeDTOs  { get; set; }
    public ICollection<ReferralDTO>?            ReferralDTOs            { get; set; }
}