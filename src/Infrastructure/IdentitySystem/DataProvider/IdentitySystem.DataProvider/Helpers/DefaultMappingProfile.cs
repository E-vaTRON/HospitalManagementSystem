namespace IdentitySystem.DataProvider;

public class DefaultMappingProfile : Profile
{
    public DefaultMappingProfile()
    {
        AllowNullCollections = true;
        AllowNullDestinationValues = true;

        var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

        CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
        CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

        CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
        CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

        CreateMap<Domain.Notification, Notification>().ReverseMap();

        CreateMap<Domain.ScheduleDay,   ScheduleDay>().ReverseMap();
        CreateMap<Domain.ScheduleSlot,  ScheduleSlot>().ReverseMap();

        CreateMap<Domain.User, User>().ReverseMap();
        CreateMap<Domain.Role, Role>().ReverseMap();

        CreateMap<Domain.UserRole,  UserRole>().ReverseMap();
        CreateMap<Domain.UserClaim, UserClaim>().ReverseMap();
        CreateMap<Domain.UserLogin, UserLogin>().ReverseMap();
        CreateMap<Domain.UserToken, UserToken>().ReverseMap();
        CreateMap<Domain.RoleClaim, RoleClaim>().ReverseMap();

        CreateMap<Domain.UserSpecialization,    UserSpecialization>().ReverseMap();
        CreateMap<Domain.Specialization,        Specialization>().ReverseMap();
    }
}
