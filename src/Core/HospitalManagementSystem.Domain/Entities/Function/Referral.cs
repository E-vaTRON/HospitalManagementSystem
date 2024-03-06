namespace HospitalManagementSystem.Domain;

public class Referral : EntityBase
{
    public DateTime DateOfReferral  { get; set; }
    public string?  Reason          { get; set; }
    public string?  Status          { get; set; }
    public string?  Urgency         { get; set; } // ???

    public string?      MedicalExamId   { get; set; }
    public MedicalExam  MedicalExam     { get; set; } = default!;

    public virtual ICollection<MedicalExamAssignment> MedicalExamAssignments { get; set; } = new HashSet<MedicalExamAssignment>();
}
