namespace HospitalManagementSystem.DataProvider;

public class ReferralDoctor : ModelBase
{
    public string?  ReferralStatus   { get; set; }

    public string?  ReferredDoctorId    { get; set; } // User Id Role<Doctor>

    public string?  ReferralId          { get; set; }
    public Referral Referral            { get; set; } = default!;

    public string?              AssignmentHistoryId { get; set; }
    public AssignmentHistory?   AssignmentHistory   { get; set; }
}
