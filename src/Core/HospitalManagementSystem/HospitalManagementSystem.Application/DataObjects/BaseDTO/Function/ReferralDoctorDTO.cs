namespace HospitalManagementSystem.Application;

public class ReferralDoctorDTO : DTOBase
{
    public string?  ReferralStatus   { get; set; }

    public string?  ReferredDoctorId    { get; set; } // User Id Role<Doctor>


    public ReferralDTO              ReferralDTO            { get; set; } = default!;

    public AssignmentHistoryDTO?    AssignmentHistoryDTO   { get; set; }
}
