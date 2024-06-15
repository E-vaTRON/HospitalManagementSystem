namespace HospitalManagementSystem.Blazor;

public partial class Login : LayoutComponentBase
{
    #region [ Properties - Inject ]
    public LoginState State { get; set; } = null!;

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; } = default!;

    [Inject]
    public ILocalStorageService LocalStorageService { get; set; } = default!;

    [Inject]
    public IToastService ToastService { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigator { get; set; } = default!;
    #endregion

    #region [ CTor ]
    //public Login(NavigationManager navigator) 
    //{
    //    Navigator = navigator;
    //}
    #endregion

    #region [ Override ]
    protected override async Task OnInitializedAsync()
    {
        this.State = new LoginState();
        State.LoginMode = new LoginModel();
        await base.OnInitializedAsync();

    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            var token = await LocalStorageService.GetItemAsStringAsync("token");
            if (token is not null)
            {
                //Navigator.NavigateTo("/home", replace: true);
            }
        }
    }
    #endregion

    #region [ Methods ]
    private async Task HandleValidSubmit()
    {
        State.IsBusy = true;
        State.UserNameLoginModel = new UserNameLoginRecord(State.LoginMode.LoginValue!, State.LoginMode.Password!);
        var response = await AuthenticationService.LoginWithUserName(State.UserNameLoginModel, "Web", default);
        response.TryPickT0(out var result, out var error);
        if (result is null)
        {
            ToastService.ShowToast(ToastIntent.Error, error.ErrorMessage);
            State.IsBusy = false;
            return;
        }

        //var token = result.accessToken;
        //if (token is null)
        //{
        //    ToastService.ShowToast(ToastIntent.Error, "Can't get token");
        //    State.IsBusy = false;
        //    return;
        //}

        //await LocalStorageService.SetItemAsStringAsync("token", token);
        //await LocalStorageService.SetItemAsStringAsync("userId", result.userGuid);

        State.IsBusy = false;
        StateHasChanged();
        Navigator.NavigateTo("/home", replace: true);
    }
    #endregion
}
