namespace HospitalManagementSystem.Application;

public record ReferralDoctorDTO : DTOBase
{
    public string?  ReferralStatus   { get; init; }

    public string?  ReferredDoctorId    { get; init; } // User Id Role<Doctor>
}
