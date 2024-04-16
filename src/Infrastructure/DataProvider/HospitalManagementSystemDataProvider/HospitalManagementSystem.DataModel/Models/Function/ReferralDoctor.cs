namespace HospitalManagementSystem.DataProvider;

public class ReferralDoctor : ModelBase
{
    public string?  ReferralStatus   { get; set; }

    public string?  ReferredDoctorId    { get; set; } // User Id Role<Doctor>

    public Guid?    ReferralId          { get; set; }
    public Referral Referral            { get; set; } = default!;

    public AssignmentHistory?   AssignmentHistory   { get; set; } // This is Principal Table
}
