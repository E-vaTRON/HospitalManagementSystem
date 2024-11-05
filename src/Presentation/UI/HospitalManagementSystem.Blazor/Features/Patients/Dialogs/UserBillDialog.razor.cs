namespace HospitalManagementSystem.Blazor;

public partial class UserBillDialog : IDialogContentComponent<UserWithPaymentModel>
{
    #region [ Properties - Inject ]
    [Inject]
    protected IToastService ToastService { get; set; }

    [Inject]
    protected IJSRuntime JSRuntime { get; set; }
    #endregion

    #region [ Properties - Parameter ]
    [Parameter]
    public UserWithPaymentModel Content { get; set; } = default!;
    #endregion

    #region [ CTor ]
    public UserBillDialog(IToastService toastService, IJSRuntime jSRuntime)
    {
        this.ToastService = toastService;
        this.JSRuntime = jSRuntime;
    }
    #endregion

    #region [ Methods ]
    private string SetUserFullName(UserWithPaymentModel user)
        => $"{user.FirstName} {user.LastName}";

    private string SetPaidDateColor(OutputBillDTO bill)
    {
        if (bill.ExcessAmount > 0)
            return "#b8d292";
        else if (bill.UnderPaidAmount > 0)
            return "#ffc225";
        else if (bill.PaidDate.HasValue)
            return "#64e34e";
        else return "red";
    }

    #region [ Converter ]
    private PresenceStatus StatusConverter(bool isFullyPaid)
        => isFullyPaid ? PresenceStatus.Available : PresenceStatus.Busy;

    private string StatusTextConverter(bool isFullyPaid)
        => isFullyPaid ? "Fully Paid" : "Not Fully Paid";
    #endregion

    #region [ Price - Calculation ]
    private string PriceInTotal()
    {
        if (Content.Bills != null && Content.Bills.Any())
        {
            decimal totalAmount = 0;

            foreach (var bill in Content.Bills)
            {
                totalAmount = CalculateAmountPerBill(bill);
            }

            return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
        }

        return "₱0.00";
    }

    private string PricePerBill(OutputBillDTO bill)
    {
        if (Content.Bills != null && Content.Bills.Any(x => x.Id == bill.Id))
        {
            var totalAmount = CalculateAmountPerBill(bill);

            return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
        }

        return "₱0.00";
    }
    //BLS
    private decimal CalculateAmountPerBill(OutputBillDTO bill)
    {
        decimal totalAmount = 0;

        foreach (var episodeService in bill.MedicalExamEpisode!.ServiceEpisodes!)
        {
            if (episodeService.MedicalService != null)
            {
                totalAmount += episodeService.MedicalService!.ServicePrice;
            }
        }

        // Calculate based on drug prescriptions
        foreach (var drugPrescription in bill.MedicalExamEpisode!.DrugPrescriptions!)
        {
            if (drugPrescription.DrugInventory != null)
            {
                totalAmount += drugPrescription.DrugInventory.Drug!.UnitPrice * drugPrescription.Amount;
            }
        }

        // Calculate based on room allocations (if applicable)
        foreach (var roomAllocation in bill.MedicalExamEpisode!.RoomAllocations!)
        {
            if (roomAllocation.Room != null)
            {
                totalAmount += roomAllocation.Room.PricePerHour * (roomAllocation.EndTime - roomAllocation.StartTime).Hours;
            }
        }

        totalAmount += bill.MedicalExamEpisode!.TotalPrice;

        return totalAmount;
    }
    #endregion

    private async Task CopyToClipboard(string text)
    {
        await JSRuntime.InvokeVoidAsync("clipboardInterop.copyText", text);
        ToastService.ShowToast(ToastIntent.Success, "Copied to clipboard");
    }
    #endregion
}
