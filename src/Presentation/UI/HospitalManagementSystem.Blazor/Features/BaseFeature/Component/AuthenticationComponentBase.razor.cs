namespace HospitalManagementSystem.Blazor;

public partial class AuthenticationComponentBase : ComponentBase
{
    #region [ Properties - Inject ]
    [Inject]
    protected ILocalStorageService LocalStorage { get; set; } = null!;

    [Inject]
    protected IJSRuntime JSRuntime { get; set; } = null!;

    [Inject]
    protected IToastService ToastService { get; set; } = null!;

    [Inject]
    protected IDialogService DialogService { get; set; } = null!;

    [Inject]
    protected NavigationManager Navigator { get; set; } = default!;
    #endregion

    #region
    public AuthenticationComponentBase()
    {
    }
    #endregion

    #region [ Override ]
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }
    #endregion

    #region [ Methods ]
    protected virtual async Task<bool> IsNotLogin()
    {
        var token = await this.LocalStorage.GetItemAsStringAsync("token");
        if (string.IsNullOrEmpty(token))
        {
            return true;
        }
        return false;
    }
    #endregion
}

