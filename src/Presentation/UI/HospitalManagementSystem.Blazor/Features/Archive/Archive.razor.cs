namespace HospitalManagementSystem.Blazor;

public partial class Archive : AuthenticationComponentBase
{
    #region [ Properties - Inject ]
    private ArchiveState State { get; set; } = null!;

    [Inject]
    private HMSServiceContext HMSContext { get; set; } = default!;

    [Inject]
    private ISServiceContext ISContext { get; set; } = default!;
    #endregion

    #region [ CTor ]
    public Archive( )
    {

    }
    #endregion

    #region [ Overrides ]

    protected override async Task OnInitializedAsync()
    {
        State = new();
        State.ItemsPerPage = 15;
        State.UserCurrentPage = 1;
        State.BillCurrentPage = 1;
        State.ServiceCurrentPage = 1;
        State.DrugCurrentPage = 1;
        State.RoomCurrentPage = 1;
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
    #region [ Delete - Restore ]
    #region [ Bill ]
    private async Task DeleteBillAsync(ArchiveBillWithUserModel bill)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {bill.Id} will be permanently deleted?",
                                                                "Yes", "No",
                                                                "Do you want to delete this record?");
        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        bill.IsDeleted = true;
        bill.DeleteOn = DateTime.UtcNow;
        await HMSContext.Bills.UpdateAsync(bill);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record deleted permanently.");
    }
    private async Task RestoreBillAsync(ArchiveBillWithUserModel bill)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {bill.Id} will be restore?",
                                                                "Yes", "No",
                                                                "Do you want to restore this bill?");
        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        bill.IsDeleted = false;
        bill.DeleteOn = default(DateTime)!;
        await HMSContext.Bills.UpdateAsync(bill);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record restored.");
    }
    #endregion

    #region [ User ]
    private async Task DeleteUserAsync(ArchiveUserWithPoliciesModel user)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {user.Email} will be delete permanently?",
                                                                "Yes", "No",
                                                                "Do you want to delete this user?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        user.IsDeleted = true;
        user.DeleteOn = DateTime.UtcNow;
        await ISContext.Users.UpdateAsync(user);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "User deleted permanently !!!");
    }
    private async Task RestoreUserAsync(ArchiveUserWithPoliciesModel user)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {user.Email} will be restored?",
                                                                "Yes", "No",
                                                                "Do you want to restore this user?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        user.IsDeleted = false;
        user.DeleteOn = default(DateTime)!;
        await ISContext.Users.UpdateAsync(user);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "User restored !!!");
    }
    #endregion

    #region [ Service ]
    private async Task DeleteServiceAsync(ArchiveServiceModel service)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {service.Name} will be permanently deleted?",
                                                                "Yes", "No",
                                                                "Do you want to delete this service?");
        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        service.IsDeleted = true;
        service.DeleteOn = DateTime.UtcNow;
        await HMSContext.MedicalServices.UpdateAsync(service);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record deleted permanently.");
    }
    private async Task RestoreServiceAsync(ArchiveServiceModel service)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {service.Name} will be restore?",
                                                                           "Yes", "No",
                                                                           "Do you want to restore this service?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        service.IsDeleted = false;
        service.DeleteOn = default(DateTime)!;
        await HMSContext.MedicalServices.UpdateAsync(service);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record restored.");
    }
    #endregion

    #region [ Drug ]
    private async Task DeleteDrugAsync(ArchiveDrugModel drug)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {drug.GoodName} will be permanently deleted?",
                                                                "Yes", "No",
                                                                "Do you want to delete this service?");
        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        drug.IsDeleted = true;
        drug.DeleteOn = DateTime.UtcNow;
        await HMSContext.Drugs.UpdateAsync(drug);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record deleted permanently.");
    }
    private async Task RestoreDrugAsync(ArchiveDrugModel drug)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {drug.GoodName} will be restore?",
                                                                           "Yes", "No",
                                                                           "Do you want to restore this service?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        drug.IsDeleted = false;
        drug.DeleteOn = default(DateTime)!;
        await HMSContext.Drugs.UpdateAsync(drug);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record restored.");
    }
    #endregion

    #region [ Room ]
    private async Task DeleteRoomAsync(ArchiveRoomModel room)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {room.Name} will be permanently deleted?",
                                                                "Yes", "No",
                                                                "Do you want to delete this service?");
        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        room.IsDeleted = true;
        room.DeleteOn = DateTime.UtcNow;
        await HMSContext.Rooms.UpdateAsync(room);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record deleted permanently.");
    }
    private async Task RestoreRoomAsync(ArchiveRoomModel room)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {room.Name} will be restore?",
                                                                           "Yes", "No",
                                                                           "Do you want to restore this service?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        room.IsDeleted = false;
        room.DeleteOn = default(DateTime)!;
        await HMSContext.Rooms.UpdateAsync(room);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record restored.");
    }
    #endregion
    #endregion

    #region [ Price - Calculation ]
    private string PricePerBill(ArchiveBillWithUserModel bill)
    {
        var totalAmount = CalculateAmountPerBill(bill);
        return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
    }

    private decimal CalculateAmountPerBill(ArchiveBillWithUserModel bill)
    {
        decimal totalAmount = 0;

        foreach (var episodeService in bill.Episode!.ServiceEpisodes!)
        {
            if (episodeService.MedicalService != null)
            {
                totalAmount += episodeService.MedicalService.ServicePrice;
            }
        }

        // Calculate based on drug prescriptions
        foreach (var drugPrescription in bill.Episode!.DrugPrescriptions!)
        {
            if (drugPrescription.DrugInventory != null)
            {
                totalAmount += drugPrescription.DrugInventory.Drug!.UnitPrice * drugPrescription.Amount;
            }
        }

        // Calculate based on room allocations (if applicable)
        foreach (var roomAllocation in bill.Episode!.RoomAllocations!)
        {
            if (roomAllocation.Room != null)
            {
                totalAmount += roomAllocation.Room.PricePerHour * (roomAllocation.EndTime - roomAllocation.StartTime).Hours;
            }
        }

        return totalAmount;
    }
    #endregion

    #region [ Appearance ]
    private void HandleOnTabChange(FluentTab tab)
    {

    }

    private Appearance PageUsersButtonAppearance(int pageIndex)
        => State.UserCurrentPage == pageIndex ? Appearance.Accent : Appearance.Neutral;

    private Appearance PageBillsButtonAppearance(int pageIndex)
        => State.BillCurrentPage == pageIndex ? Appearance.Accent : Appearance.Neutral;

    private Appearance PageServicesButtonAppearance(int pageIndex)
        => State.ServiceCurrentPage == pageIndex ? Appearance.Accent : Appearance.Neutral;

    private async Task CopyToClipboard(string text)
    {
        await JSRuntime.InvokeVoidAsync("clipboardInterop.copyText", text);
        ToastService.ShowToast(ToastIntent.Success, "Copied ID to clipboard");
    }
    #endregion

    #region [ Refresh Data ]
    private void RefreshData(int currentPage = 1)
    {
        RefreshUsersData(currentPage);
        RefreshBillsData(currentPage);
        RefreshServicesData(currentPage);
        RefreshDrugsData(currentPage);
        RefreshRoomsData(currentPage);

        StateHasChanged();
    }

    private void RefreshUsersData(int currentPage = 1)
    {
        State.ModifiedUsers.Clear();

        var usersData = State.Users
            .Select(user =>
            {
                var archiveUser = new ArchiveUserWithPoliciesModel();

                //foreach (var property in typeof(ArchiveUserWithPoliciesModel).GetProperties())
                //{
                //    var matchingProperty = typeof(OutputUserDTO).GetProperty(property.Name);
                //    if (matchingProperty != null)
                //    {
                //        var value = matchingProperty.GetValue(user);
                //        property.SetValue(archiveUser, value);
                //    }
                //}
                typeof(ArchiveUserWithPoliciesModel).GetProperties().ToList().ForEach(property =>
                {
                    var matchingProperty = typeof(OutputUserDTO).GetProperty(property.Name);
                    if (matchingProperty != null)
                    {
                        var value = matchingProperty.GetValue(user);
                        property.SetValue(archiveUser, value);
                    }
                });
                archiveUser.UserRoles = user.UserRoleDTOs;
                archiveUser.UserClaims = user.UserClaimDTOs;
                return archiveUser;
            })
            .OrderByDescending(user => user.CreatedOn);

        State.ModifiedUsers = usersData.Skip((currentPage - 1) * State.ItemsPerPage)
                                      .Take(State.ItemsPerPage).ToList();
        StateHasChanged();
    }

    private void RefreshBillsData(int currentPage = 1)
    {
        State.ModifiedBills.Clear();

        var billsData = State.Bills
            .Join(State.Users,
                   bill => bill.MedicalExamEpisode!.MedicalExam!.BookingAppointment!.PatientId,
                   user => user.Id,
                   (bill, user) => new ArchiveBillWithUserModel
                   {
                       Id = bill.Id,
                       Deadline = bill.Deadline,
                       PaidDate = bill.PaidDate,
                       ExcessAmount = bill.ExcessAmount,
                       UnderPaidAmount = bill.UnderPaidAmount,
                       CreatedOn = bill.CreatedOn,
                       User = user,
                       Episode = bill.MedicalExamEpisode!
                   })
            .OrderByDescending(user => user.CreatedOn);

        State.ModifiedBills = billsData.Skip((currentPage - 1) * State.ItemsPerPage)
                                       .Take(State.ItemsPerPage).ToList();
        StateHasChanged();
    }

    private void RefreshServicesData(int currentPage = 1)
    {
        State.ModifiedServices.Clear();

        var servicesData = State.Services
            .Select(service =>
            {
                var archiveService = new ArchiveServiceModel();

                typeof(ArchiveServiceModel).GetProperties().ToList().ForEach(property =>
                {
                    var matchingProperty = typeof(OutputMedicalServiceDTO).GetProperty(property.Name);
                    if (matchingProperty != null)
                    {
                        var value = matchingProperty.GetValue(service);
                        property.SetValue(archiveService, value);
                    }
                });
                return archiveService;
            })
            .OrderByDescending(service => service.CreatedOn);

        State.ModifiedServices = servicesData.Skip((currentPage - 1) * State.ItemsPerPage)
                                             .Take(State.ItemsPerPage).ToList();

        StateHasChanged();
    }

    private void RefreshDrugsData(int currentPage = 1)
    {
        State.ModifiedDrugs.Clear();

        var drugsData = State.Drugs
            .Select(drug =>
            {
                var archiveDrug = new ArchiveDrugModel();

                typeof(ArchiveDrugModel).GetProperties().ToList().ForEach(property =>
                {
                    var matchingProperty = typeof(OutputDrugDTO).GetProperty(property.Name);
                    if (matchingProperty != null)
                    {
                        var value = matchingProperty.GetValue(drug);
                        property.SetValue(archiveDrug, value);
                    }
                });
                return archiveDrug;
            })
            .OrderByDescending(service => service.CreatedOn);

        State.ModifiedDrugs = drugsData.Skip((currentPage - 1) * State.ItemsPerPage)
                                       .Take(State.ItemsPerPage).ToList();
        StateHasChanged();
    }

    private void RefreshRoomsData(int currentPage = 1)
    {
        State.ModifiedRooms.Clear();

        var roomsData = State.Rooms
            .Select(room =>
            {
                var archiveRoom = new ArchiveRoomModel();

                typeof(ArchiveRoomModel).GetProperties().ToList().ForEach(property =>
                {
                    var matchingProperty = typeof(OutputRoomDTO).GetProperty(property.Name);
                    if (matchingProperty != null)
                    {
                        var value = matchingProperty.GetValue(room);
                        property.SetValue(archiveRoom, value);
                    }
                });
                return archiveRoom;
            })
            .OrderByDescending(service => service.CreatedOn);

        State.ModifiedRooms = roomsData.Skip((currentPage - 1) * State.ItemsPerPage)
                                       .Take(State.ItemsPerPage).ToList();

        StateHasChanged();
    }
    #endregion

    #region [ LoadData ]
    private async Task LoadDataAsync()
    {
        State.Users.Clear();
        State.Bills.Clear();
        State.Services.Clear();
        State.Drugs.Clear();
        State.Rooms.Clear();
        State.BillPaginationCount = [];
        State.UserPaginationCount = [];
        State.ServicePaginationCount = [];
        State.DrugPaginationCount = [];
        State.RoomPaginationCount = [];
        State.ItemsPerPage = 15;

        var users = await ISContext.Users.GetUsersInRoleAsync("Patient");

        var bills = await HMSContext.Bills.GetBillByMultipleUserIdAsync(State.Users.Select(x => x.Id).ToArray(), true);

        var services = await HMSContext.MedicalServices.FindAllAsync();

        var drugs = await HMSContext.Drugs.FindAllAsync();

        var rooms = await HMSContext.Rooms.FindAllAsync();

        State.Users = users.ToList();
        State.Bills = bills.ToList();
        State.Services = services.ToList();
        State.Drugs = drugs.ToList();
        State.Rooms = rooms.ToList();

        //foreach (var bill in bills)
        //{
        //    var analysisTestIds = bill.MedicalExamEpisodeDTO!.AnalysisTestDTOs!.Select(x => x.Id).ToArray();
        //    var analysisTests = await HMSContext.AnalysisTests.GetMultipleByIdIncludeServiceAsync(analysisTestIds);

        //    var drugPrescriptionIds = bill.MedicalExamEpisodeDTO!.DrugPrescriptionDTOs!.Select(x => x.Id).ToArray();
        //    var drugPrescriptions = await HMSContext.DrugPrescriptions.GetMultipleByIdIncludeDrugAsync(drugPrescriptionIds);

        //    var roomAllocationIds = bill.MedicalExamEpisodeDTO!.RoomAllocationDTOs!.Select(x => x.Id).ToArray();
        //    var roomAllocations = await HMSContext.RoomAllocations.GetMultipleByIdIncludeRoomAsync(roomAllocationIds);

        //    var updatedMedicalExamEpisodeDTO = bill.MedicalExamEpisodeDTO with
        //    {
        //        AnalysisTestDTOs = analysisTests.ToList(),
        //        DrugPrescriptionDTOs = drugPrescriptions.ToList(),
        //        RoomAllocationDTOs = roomAllocations.ToList()
        //    };

        //    var updatedBill = bill with { MedicalExamEpisodeDTO = updatedMedicalExamEpisodeDTO };

        //    State.Bills.Add(updatedBill);
        //}


        State.BillPaginationCount = Enumerable
            .Range(1, (int)Math.Ceiling((double)State.Bills.Count / State.ItemsPerPage))
            .ToArray();

        State.UserPaginationCount = Enumerable
            .Range(1, (int)Math.Ceiling((double)State.Users.Count / State.ItemsPerPage))
            .ToArray();

        State.ServicePaginationCount = Enumerable
            .Range(1, (int)Math.Ceiling((double)State.Services.Count / State.ItemsPerPage))
            .ToArray();

        State.DrugPaginationCount = Enumerable
            .Range(1, (int)Math.Ceiling((double)State.Drugs.Count / State.ItemsPerPage))
            .ToArray();

        State.RoomPaginationCount = Enumerable
            .Range(1, (int)Math.Ceiling((double)State.Rooms.Count / State.ItemsPerPage))
            .ToArray();

        RefreshUsersData();
        RefreshBillsData();

        this.StateHasChanged();
    }
    #endregion
    #endregion
}
