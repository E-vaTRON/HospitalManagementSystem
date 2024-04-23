namespace HospitalManagementSystem.DataProvider;

public class SeedProvider
{
    #region [ Singleton ]
    private static readonly Lazy<SeedProvider> seed = new Lazy<SeedProvider>(() => new SeedProvider(), LazyThreadSafetyMode.PublicationOnly);
    public static SeedProvider Seed
    {
        get { return seed.Value; }
    }
    #endregion

    #region [ CTor ]
    public SeedProvider()
    {
        // init


        this.Clear();
        this.Load();
    }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
    }

    private void Clear()
    {
    }
    #endregion

    #region [ Seed Create ]
    #endregion
}
