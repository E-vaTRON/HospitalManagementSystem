namespace HospitalManagementSystem.Application;

public record ReferralDTO : DTOBase
{
    public DateTime DateOfReferral  { get; init; }
    public string?  Reason          { get; init; }
    public string?  Urgency         { get; init; } // ???
}
