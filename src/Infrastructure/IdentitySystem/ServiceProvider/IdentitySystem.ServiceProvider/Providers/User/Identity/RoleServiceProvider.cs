namespace IdentitySystem.ServiceProvider;

public class RoleServiceProvider : IRoleServiceProvider
{
    #region [ Field ]
    private readonly IRoleDataProvider DataProvider;
    #endregion

    #region [ CTor ]
    public RoleServiceProvider(IRoleDataProvider dataProvider)
    {
        DataProvider = dataProvider;
    }
    #endregion
}
