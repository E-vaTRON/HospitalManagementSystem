namespace IdentitySystem.Application;

public record OutputUserDTO : UserDTO
{
    public ICollection<UserRoleDTO>?        UserRoleDTOs        { get; init; }
    public ICollection<UserClaimDTO>?       UserClaimDTOs       { get; init; }
    public ICollection<UserLoginDTO>?       UserLoginDTOs       { get; init; }
    public ICollection<UserTokenDTO>?       UserTokenDTOs       { get; init; }
    public ICollection<NotificationDTO>?    NotificationDTOs    { get; init; }
    public ICollection<SpecializationDTO>?  SpecializationDTOs  { get; init; }
    public ICollection<ScheduleDayDTO>?     ScheduleDayDTOs     { get; init; }
}
