using OneOf;

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
        var response = new OneOf<ServiceSuccess, ServiceError>();
        // Check if LoginValue is an email
        if (new EmailAddressAttribute().IsValid(State.LoginMode.LoginValue))
        {
            var model = new EmailLoginRecord(State.LoginMode.LoginValue!, State.LoginMode.Password!);
            response = await AuthenticationService.LoginWithEmail(model, "Web", default);
        }
        // Check if LoginValue is a phone number
        else if (new PhoneAttribute().IsValid(State.LoginMode.LoginValue))
        {
            var model = new PhoneNumberLoginRecord(State.LoginMode.LoginValue!, State.LoginMode.Password!);
            response = await AuthenticationService.LoginWithPhoneNumber(model, "Web", default);
        }
        // If it's not an email or a phone number, assume it's a username
        else
        {
            var model = new UserNameLoginRecord(State.LoginMode.LoginValue!, State.LoginMode.Password!);
            response = await AuthenticationService.LoginWithUserName(model, "Web", default);
        }

        response.TryPickT0(out var result, out var error);
        if (result is null)
        {
            ToastService.ShowToast(ToastIntent.Error, error.ErrorMessage);
            State.IsBusy = false;
            return;
        }

        var authResponse = result.AttachedData as AuthenticatedResponse;
        if (authResponse is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Can't get token");
            State.IsBusy = false;
            return;
        }

        await LocalStorageService.SetItemAsStringAsync("token", authResponse.accessToken);
        await LocalStorageService.SetItemAsStringAsync("userId", authResponse.userId);

        State.IsBusy = false;
        StateHasChanged();
        Navigator.NavigateTo("/home", replace: true);
    }
    #endregion
}
