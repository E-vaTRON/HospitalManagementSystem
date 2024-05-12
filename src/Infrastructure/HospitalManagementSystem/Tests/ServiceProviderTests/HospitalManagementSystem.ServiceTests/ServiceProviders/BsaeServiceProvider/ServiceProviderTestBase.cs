namespace HospitalManagementSystem.Tests;

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
        });
        Mapper = new Mapper(configuration);
    }
        #endregion
}
