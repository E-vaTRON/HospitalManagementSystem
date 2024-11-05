namespace HospitalManagementSystem.Blazor;

public partial class EditServiceDialog : IDialogContentComponent<ServiceWithDeviceModel>
{
    #region [ Properties Inject ]
    [Inject]
    public HMSServiceContext HMSContext { get; set; } = default!;
    #endregion

    #region [ Properties Parameter ]
    [Parameter]
    public ServiceWithDeviceModel Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog? Dialog { get; set; }
    #endregion

    protected override async Task OnInitializedAsync()
    {
        ValidateService();
        await base.OnInitializedAsync();
    }

    private bool IsHexColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return false;

        if (color[0] == '#')
            color = color.Substring(1);

        return color.Length == 6 && int.TryParse(color, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _);
    }

    async void ValidateAndSetIsServiceNameValid()
    {
        string pattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        bool regexValid = Regex.IsMatch(Content.Name ?? "", pattern);
        var duplicateName = await HMSContext.MedicalServices.FindAllWithPredicateAsync(x => !x.IsDeleted);
        bool isDuplicate = duplicateName.ToList().Any(s => s.Name == Content.Name);
        if (regexValid && !isDuplicate)
            Content.IsServiceNameValid = true;
        else
        {
            Content.IsServiceNameValid = false;
            Content.IsNameNotDuplicated = !isDuplicate;
        }

    }

    void ValidateAndSetIsPriceValid()
        => Content.IsPriceValid = Content.ServicePrice > 0;

    void ValidateService()
    {
        ValidateAndSetIsServiceNameValid();
        ValidateAndSetIsPriceValid();

        if (Content.IsServiceNameValid && Content.IsPriceValid)
            Dialog?.TogglePrimaryActionButton(true);
    }
}
