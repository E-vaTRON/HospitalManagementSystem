namespace HospitalManagementSystem.Domain;

public class ReferralDoctor : EntityBase
{
    public string?  ReferralStatus   { get; set; }

    public string?  ReferredDoctorId    { get; set; }
    public Doctor   ReferredDoctor      { get; set; } = default!;
    public string?  ReferralId          { get; set; }
    public Referral Referral            { get; set; } = default!;

    //public string?              AssignmentHistoryId { get; set; }
    //public AssignmentHistory?   AssignmentHistory   { get; set; }
}
