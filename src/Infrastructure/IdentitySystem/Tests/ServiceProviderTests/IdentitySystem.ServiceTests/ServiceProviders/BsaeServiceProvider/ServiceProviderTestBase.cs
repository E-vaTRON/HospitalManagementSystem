namespace IdentitySystem.Tests;

public abstract class ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly IMapper Mapper;
    protected readonly Fixture Fixture;
    #endregion

    #region [ CTor ]
    public ServiceProviderTestBase()
    {
        this.Fixture = new Fixture();
        Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                         .ForEach(b => Fixture.Behaviors.Remove(b));
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 1));
        Fixture.Customize(new FixtureCustomization());

        var configuration = new MapperConfiguration(config =>
        {
            config.AllowNullCollections = true;
            config.AllowNullDestinationValues = true;

            var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

            config.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
            config.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

            config.CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
            config.CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

            config.CreateMap<NotificationDTO, Domain.Notification>().ReverseMap();

            config.CreateMap<ScheduleDayDTO,    Domain.ScheduleDay>().ReverseMap();
            config.CreateMap<ScheduleSlotDTO,   Domain.ScheduleSlot>().ReverseMap();

            config.CreateMap<UserDTO,       Domain.User>().ReverseMap();
            config.CreateMap<UserCreateDTO, UserDTO>().ReverseMap();
            config.CreateMap<RoleDTO,       Domain.Role>().ReverseMap();
            config.CreateMap<UserRoleDTO,   Domain.UserRole>().ReverseMap();

            config.CreateMap<SpecializationDTO, Domain.Specialization>().ReverseMap();
        });
        Mapper = new Mapper(configuration);
    }
        #endregion
}
