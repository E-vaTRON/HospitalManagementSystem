namespace HospitalManagementSystem.Blazor;

public partial class UserInfoLayout : ComponentBase
{
    #region [ Properties - Inject ]
    [Inject]
    protected IMapper Mapper { get; set; }

    [Inject]
    protected ILocalStorageService LocalStorage { get; set; }

    [Inject]
    protected IUserServiceProvider UserServiceProvider { get; set; }

    [Inject]
    protected NavigationManager Navigator { get; set; }
    #endregion

    #region [ Properties - Parameter ]
    [Parameter]
    public EventCallback<bool> DarkModeToggled { get; set; }
    
    [Parameter]
    public DesignThemeModes Mode { get; set; } = DesignThemeModes.Dark;
    #endregion

    #region [ Properties ]
    OutputUserDTO? UserInfo { get; set; }

    public bool IsDarkMode { get; set; } = true;
    #endregion

    #region [ CTor ]
    public UserInfoLayout( IUserServiceProvider userServiceProvider, 
                           ILocalStorageService localStorageService, 
                           IMapper mapper, 
                           NavigationManager navigationManager )
    {
        UserServiceProvider = userServiceProvider;
        LocalStorage = localStorageService;
        Mapper = mapper;
        Navigator = navigationManager;
    }
    #endregion

    #region []
    protected override Task OnInitializedAsync()
    {

        Mode = IsDarkMode ? DesignThemeModes.Dark : DesignThemeModes.Light;
        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Fetch user information from localStorage
            var userGuid = await LocalStorage.GetItemAsync<string>("userId");
            if (userGuid is null)
                return;


            UserInfo = await UserServiceProvider.FindByIdAsync(userGuid);
            if (UserInfo is null)
                return;


            // var savedThemeMode = await _localStorage.GetItemAsync<string>("theme");
            // if (savedThemeMode is null)
            //     isDarkMode = true;
            // isDarkMode = savedThemeMode == "Dark" ? true : false;
            // Mode = savedThemeMode == "Dark" ? DesignThemeModes.Dark : DesignThemeModes.Light;
            StateHasChanged();
        }
    }

    private async Task Logout()
    {
        // Handle logout logic
        await LocalStorage.ClearAsync();
        Navigator.NavigateTo("/"); // Redirect to the logout page or perform logout actions
    }

    private void ChangeTheme(bool value)
    {
        // isDarkMode = value;
        // await DarkModeToggled.InvokeAsync(isDarkMode);
        // Mode = isDarkMode ? DesignThemeModes.Dark : DesignThemeModes.Light;
        // await _localStorage.SetItemAsStringAsync("theme", isDarkMode ? "Dark" : "Light");
    }
    #endregion
}
