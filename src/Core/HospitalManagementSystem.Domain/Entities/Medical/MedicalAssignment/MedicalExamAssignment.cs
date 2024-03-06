namespace HospitalManagementSystem.Domain;

public class MedicalExamAssignment : EntityBase
{
    public string? ReferralStatus { get; set; }

    public string?              ReferralId              { get; set; }
    public Referral             Referral                { get; set; } = default!;
    public string?              ReferringDoctorId       { get; set; }
    public Doctor               ReferringDoctor         { get; set; } = default!;
    public string?              ReferredDoctorId        { get; set; }
    public Doctor               ReferredDoctor          { get; set; } = default!;
    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}
