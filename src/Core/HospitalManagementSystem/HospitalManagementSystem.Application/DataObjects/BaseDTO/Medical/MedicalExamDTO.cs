namespace HospitalManagementSystem.Application;

public class MedicalExamDTO : DTOBase
{
    public int? FinalPrice { get; set; }

    public BookingAppointmentDTO?  BookingAppointmentDTO      { get; set; } = default!;

    public virtual ICollection<MedicalExamEpisodeDTO>   MedicalExamEpisodeDTOs { get; set; } = new HashSet<MedicalExamEpisodeDTO>();
    public virtual ICollection<ReferralDTO>             ReferralDTOs           { get; set; } = new HashSet<ReferralDTO>();
}