namespace HospitalManagementSystem.Application;

public class ReferralDTO : DTOBase
{
    public DateTime DateOfReferral  { get; set; }
    public string?  Reason          { get; set; }
    public string?  Urgency         { get; set; } // ???

    public MedicalExamDTO  MedicalExam     { get; set; } = default!;

    public virtual ICollection<AssignmentHistoryDTO> AssignmentHistoryDTOs { get; set; } = new HashSet<AssignmentHistoryDTO>();
}
