namespace HospitalManagementSystem.Blazor;

public partial class MainLayout
{
    #region [ Properties - Parameter ]
    [Parameter]
    public DesignThemeModes Mode { get; set; } = DesignThemeModes.Dark;
    #endregion


    #region [ CTor ]
    public MainLayout()
    {
    }
    #endregion
}
