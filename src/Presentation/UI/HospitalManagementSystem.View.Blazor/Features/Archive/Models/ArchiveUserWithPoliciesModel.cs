namespace HospitalManagementSystem.Blazor;

public record ArchiveUserWithPoliciesModel : InputUserDTO
{
    public ICollection<UserRoleDTO>?    UserRoles   { get; set; }
    public ICollection<UserClaimDTO>?   UserClaims  { get; set; }
}