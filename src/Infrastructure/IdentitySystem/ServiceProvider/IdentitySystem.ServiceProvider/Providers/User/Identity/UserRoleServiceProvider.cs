namespace IdentitySystem.ServiceProvider;

public class UserRoleServiceProvider : IUserRoleServiceProvider
{
    #region [ Field ]
    private readonly IUserRoleDataProvider DataProvider;
    #endregion

    #region [ CTor ]
    public UserRoleServiceProvider(IUserRoleDataProvider dataProvider)
    {
        DataProvider = dataProvider;
    }
    #endregion
}
