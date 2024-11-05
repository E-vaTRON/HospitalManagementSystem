namespace IdentitySystem.ServiceProvider;

public class MappingHelper : Profile
{
    public MappingHelper()
    {
        AllowNullCollections = true;
        AllowNullDestinationValues = true;

        var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

        CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
        CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

        CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
        CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

        // Notification
        CreateMap<Domain.Notification, InputNotificationDTO>().ReverseMap();
        CreateMap<Domain.Notification, OutputNotificationDTO>().ReverseMap();
        CreateMap<InputNotificationDTO, OutputNotificationDTO>().ReverseMap();

        // ScheduleDay
        CreateMap<Domain.ScheduleDay, InputScheduleDayDTO>().ReverseMap();
        CreateMap<Domain.ScheduleDay, OutputScheduleDayDTO>().ReverseMap();
        CreateMap<InputScheduleDayDTO, OutputScheduleDayDTO>().ReverseMap();
        // ScheduleSlot
        CreateMap<Domain.ScheduleSlot, InputScheduleSlotDTO>().ReverseMap();
        CreateMap<Domain.ScheduleSlot, OutputScheduleSlotDTO>().ReverseMap();
        CreateMap<InputScheduleSlotDTO, OutputScheduleSlotDTO>().ReverseMap();

        // User
        CreateMap<Domain.User, InputUserDTO>().ReverseMap();
        CreateMap<Domain.User, OutputUserDTO>().ReverseMap();
        CreateMap<InputUserDTO, OutputUserDTO>().ReverseMap();
        // Role
        CreateMap<Domain.Role, InputRoleDTO>().ReverseMap();
        CreateMap<Domain.Role, OutputRoleDTO>().ReverseMap();
        CreateMap<InputRoleDTO, OutputRoleDTO>().ReverseMap();

        // UserRole
        CreateMap<Domain.UserRole, InputUserRoleDTO>().ReverseMap();
        CreateMap<Domain.UserRole, OutputUserRoleDTO>().ReverseMap();
        CreateMap<InputUserRoleDTO, OutputUserRoleDTO>().ReverseMap();
        // UserClaim
        CreateMap<Domain.UserClaim, InputUserClaimDTO>().ReverseMap();
        CreateMap<Domain.UserClaim, OutputUserClaimDTO>().ReverseMap();
        CreateMap<InputUserClaimDTO, OutputUserClaimDTO>().ReverseMap();
        // UserLogin
        CreateMap<Domain.UserLogin, InputUserLoginDTO>().ReverseMap();
        CreateMap<Domain.UserLogin, OutputUserLoginDTO>().ReverseMap();
        CreateMap<InputUserLoginDTO, OutputUserLoginDTO>().ReverseMap();
        // UserToken
        CreateMap<Domain.UserToken, InputUserTokenDTO>().ReverseMap();
        CreateMap<Domain.UserToken, OutputUserTokenDTO>().ReverseMap();
        CreateMap<InputUserTokenDTO, OutputUserTokenDTO>().ReverseMap();

        // RoleClaim
        CreateMap<Domain.RoleClaim, InputRoleClaimDTO>().ReverseMap();
        CreateMap<Domain.RoleClaim, OutputRoleClaimDTO>().ReverseMap();
        CreateMap<InputRoleClaimDTO, OutputRoleClaimDTO>().ReverseMap();

        // UserSpecialization
        CreateMap<Domain.UserSpecialization, InputUserSpecializationDTO>().ReverseMap();
        CreateMap<Domain.UserSpecialization, OutputUserSpecializationDTO>().ReverseMap();
        CreateMap<InputUserSpecializationDTO, OutputUserSpecializationDTO>().ReverseMap();
        // Specialization
        CreateMap<Domain.Specialization, InputSpecializationDTO>().ReverseMap();
        CreateMap<Domain.Specialization, OutputSpecializationDTO>().ReverseMap();
        CreateMap<InputSpecializationDTO, OutputSpecializationDTO>().ReverseMap();
    }
}
