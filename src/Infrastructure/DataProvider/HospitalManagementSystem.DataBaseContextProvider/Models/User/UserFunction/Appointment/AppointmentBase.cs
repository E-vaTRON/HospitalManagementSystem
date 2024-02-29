namespace HospitalManagementSystem.DataProvider;

public class AppointmentBase : ModelBase
{
    public DateTime     AppointmentDate { get; set; } = default!;
    public string?      Notes           { get; set; }

    public string?      ReferralId      { get; set; }
    public Referral?    Referral        { get; set; } = default!;
}