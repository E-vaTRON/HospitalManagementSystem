namespace HospitalManagementSystem.Blazor;


public partial class Services : AuthenticationComponentBase
{

    #region [ Properties Inject  ]    
    private ServiceState State { get; set; } = null!;

    [Inject]
    private HMSServiceContext HMSContext { get; set; } = default!;
    #endregion

    #region [ CTor ]
    public Services( ) 
    {

    }
    #endregion

    #region [ Overrides ]
    protected override async Task OnInitializedAsync()
    {
        State = new();
        State.CurrentPage = 1;
        State.ItemsPerPage = 15;
        await base.OnInitializedAsync();
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            //if (await base.IsNotLogin())
            //{
            //    this.Navigator.NavigateTo("/login", replace: true);
            //    return;
            //}
            await LoadDataAsync();
        }
    }
    #endregion

    #region [ Methods ]
    #region [ Dialogs ]
    private async Task AddServiceDialog()
    {
        ServiceWithValidationModel service = new()
        {  };
        await DialogService.ShowDialogAsync<AddServiceDialog>(service, new DialogParameters()
        {
            Title = $"Create new service",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleDialog(result)),
            Width = "300px",
            Height = "550px",
            TrapFocus = true,
            Modal = true,
            PrimaryActionEnabled = false
        });
    }

    private async Task EditServiceDialog(ServiceWithDeviceModel service)
    {
        await DialogService.ShowDialogAsync<EditServiceDialog>(service, new DialogParameters()
        {
            Title = $"Edit service",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleDialog(result, isUpdate: true)),
            Width = "300px",
            Height = "550px",
            TrapFocus = true,
            PrimaryAction = "Update service",
            Modal = true,
            PrimaryActionEnabled = false
        });
    }
    #region [ Handle ]
    private async Task HandleDialog(DialogResult result, bool isUpdate = false)
    {
        string state = "";
        if (result.Cancelled)
            return;

        if (result.Data is null)
            return;

        if (isUpdate)
        {
            ServiceWithValidationModel? data = result.Data as ServiceWithValidationModel;
            if (data is null
            || string.IsNullOrEmpty(data.Name)
            || string.IsNullOrWhiteSpace(data.Name)
            || data.ServicePrice == 0
            || !data.IsPriceValid
            || !data.IsNameNotDuplicated)
            {
                ToastService.ShowToast(ToastIntent.Error, "Wrong information to create a service");
                return;
            }

            InputServiceDTO service = new()
            {
                Name = data!.Name,
                Unit = data!.Unit,
                UnitPrice = data!.UnitPrice,
                ServicePrice = data!.ServicePrice,
                HealthInsurancePrice = data!.HealthInsurancePrice,
                ResultFromType = data!.ResultFromType
            };

            await HMSContext.Services.AddAsync(service);
            state = "Add";
        }
        else
        {
            ServiceWithDeviceModel? data = result.Data as ServiceWithDeviceModel;

            if (data is null
                || string.IsNullOrEmpty(data.Name)
                || string.IsNullOrWhiteSpace(data.Name)
                || data.ServicePrice == 0
                || !data.IsPriceValid
                || !data.IsNameNotDuplicated)
            {
                ToastService.ShowToast(ToastIntent.Error, "Wrong information to create a service");
                return;
            }

            await HMSContext.Services.UpdateAsync(data);
            state = "Update";
        }

        ToastService.ShowToast(ToastIntent.Success, $"{state} successfully");
        await LoadDataAsync();
    }
    #endregion
    #endregion

    private async Task Delete(ServiceWithDeviceModel service)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Service {service.Name} will be move to archive?",
                                                                "Yes", "No",
                                                                "Do you want to delete this service?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        service.IsDeleted = true;
        service.DeleteOn = DateTime.UtcNow;
        await HMSContext.Services.UpdateAsync(service);

        ToastService.ShowToast(ToastIntent.Success, "Delete successfully");
        await LoadDataAsync();
    }

    #region [ Appearance ]
    private bool DisableEditButton(ServiceWithDeviceModel service)
    {
        string serviceId = service.Id.ToString(); // Assuming Id is a Guid

        return service.Id.GetType() == typeof(Guid);
    }
    private Appearance PageButtonAppearance(int pageIndex)
        => State.CurrentPage == pageIndex ? Appearance.Accent : Appearance.Neutral;
    #endregion

    #region [ Refresh Data ]
    private void RefreshData(int currentPage = 1)
    {

        var servicesData = State.Services
            .Select(service =>
            {
                var serviceWithDevice = new ServiceWithDeviceModel();

                typeof(ServiceWithDeviceModel).GetProperties().ToList().ForEach(property =>
                {
                    var matchingProperty = typeof(OutputServiceDTO).GetProperty(property.Name);
                    if (matchingProperty != null)
                    {
                        var value = matchingProperty.GetValue(service);
                        property.SetValue(serviceWithDevice, value);
                    }
                });

                service.DeviceServiceDTOs!.Select(devices => devices.DeviceInventoryDTO).ToList().ForEach(device =>
                {
                    serviceWithDevice.DevicesServiceAvailable!.Add(device!);
                });

                return serviceWithDevice;
            })
            .OrderByDescending(service => service.CreatedOn);

        StateHasChanged();
    }
    #endregion

    #region [ Load Data ]
    private async Task LoadDataAsync()
    {
        State.Services.Clear();
        State.PaginationCount = [];
        State.ItemsPerPage = 15;

        var services = await HMSContext.Services.FindAllAsync();

        var serviceIds = services.Select(x => x.Id).ToArray();
        var deviceServices = await HMSContext.DeviceServices.GetByMultipleServiceIdIncludeDeviceAsync(serviceIds);

        foreach ( var service in services)
        {
            var deviceServicesPerService = deviceServices.Where(deviceService => deviceService.ServiceDTO!.Id == service.Id).ToList();

            var updatedServiceDTO = service with
            {
                DeviceServiceDTOs = deviceServicesPerService
            };

            State.Services.Add(updatedServiceDTO);
        }

        int paginationCount = (int)Math.Ceiling((double)State.Services.Count / State.ItemsPerPage);

        State.PaginationCount = Enumerable.Range(1, paginationCount).ToArray();

        RefreshData();

        StateHasChanged();
    }
    #endregion
    #endregion
}
