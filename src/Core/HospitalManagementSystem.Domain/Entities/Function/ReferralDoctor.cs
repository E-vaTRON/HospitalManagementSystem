namespace HospitalManagementSystem.Domain;

public class ReferralDoctor
{
    public string?  ReferralStatus   { get; set; }

    public string?  ReferringDoctorId   { get; set; }
    public Doctor   ReferringDoctor     { get; set; } = default!;
    public string?  ReferredDoctorId    { get; set; }
    public Doctor   ReferredDoctor      { get; set; } = default!;

    public string?              AssignmentHistoryId { get; set; }
    public AssignmentHistory?   AssignmentHistory   { get; set; }
}
