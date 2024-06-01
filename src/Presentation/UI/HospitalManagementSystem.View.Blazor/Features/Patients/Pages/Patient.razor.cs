﻿namespace HospitalManagementSystem.Blazor;

public partial class Patient : AuthenticationComponentBase
{
    #region [ Fields ]
    [Inject]
    private PatientState State { get; set; }

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;

    [Inject]
    private IToastService ToastService { get; set; } = null!;

    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    [Inject]
    private HMSServiceContext HMSContext { get; set; }

    [Inject]
    private ISServiceContext ISContext { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; } = null!;

    //[Inject]
    //private IdentityDbContext identityDbContext { get; set; } = null!;
    #endregion

    #region [ CTor ]
    public Patient(NavigationManager navigator) : base(navigator)
    {
        State = new();
        State.ItemsPerPage = 15;
    }
    #endregion

    #region [ Overrides ]
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {

            if (await base.IsNotLogin())
            {
                this.Navigator.NavigateTo("/login", replace: true);
                return;
            }
            await RefreshAsync();
        }
    }
    #endregion

    #region [ Methods ]
    #region [ Filter - Sort ]
    private void OnLastNameFilter(string searchTerm)
    {
        if (searchTerm.Length > 0 && !string.IsNullOrWhiteSpace(searchTerm))
        {
            var filtered = this.State.UserWithPayments.Where(x => x.LastName.ToLower().Contains(searchTerm));
            this.OnFilterData(filtered);
        }
    }

    private void OnAddressFilter(string searchTerm)
    {
        if (searchTerm.Length > 0 && !string.IsNullOrWhiteSpace(searchTerm))
        {
            var filtered = this.State.UserWithPayments.Where(x => x.Address.ToLower().Contains(searchTerm));
            this.OnFilterData(filtered);
        }
    }

    private void OnFilterData(IEnumerable<UserWithPaymentModel> filtered)
    {
        this.State.UserWithPayments.Clear();
        this.State.UserWithPayments = filtered.ToList();
        this.StateHasChanged();
    }
    #endregion

    private async Task SelectMemberByFirstNameAsync(string firstName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || State.Users is null)
            return;

        var userInfo = State.UserWithPayments.FirstOrDefault(x => x.FirstName == firstName);
        if (userInfo is null)
            return;

        await UserBillDialog(userInfo);
    }

    private async Task DeleteAsync(UserWithPaymentModel userInfo)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {userInfo.Email} will be move to archive?",
                                                                "Yes", "No",
                                                                "Do you want to delete this user?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        await ISContext.Users.DeleteAsync(userInfo);

        await RefreshAsync();
        ToastService.ShowToast(ToastIntent.Success, $"User {userInfo.UserName} moved to archive !!!");
    }

    private async Task ResetToDefaultPasswordAsync(UserWithPaymentModel userInfo)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Password for {userInfo.Email} will be reset to default?",
                                                                "Yes", "No",
                                                                "Do you want to reset password?");

        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        var entity = await ISContext.Users.FindByIdAsync(userInfo.Id);
        if (entity is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "User not found in database, maybe it was deleted already.");
            return;
        }

        var resetToken = await ISContext.Users.GeneratePasswordResetTokenAsync(userInfo);
        if (resetToken is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Something is wrong with the reset token.");
            return;
        }

        await ISContext.Users.ResetPasswordAsync(userInfo, resetToken, "");
        ToastService.ShowToast(ToastIntent.Success, $"Password for {entity.UserName} reset to default !!!");
    }

    #region [ Dialogs ]
    private async Task UserBillDialog(UserWithPaymentModel userInfo)
    {
        await DialogService.ShowDialogAsync<UserBillDialog>(userInfo, new DialogParameters()
        {
            Title = $"{userInfo.FirstName} {userInfo.LastName}",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => { }),
            Width = "980px",
            Height = "565px",
            TrapFocus = true,
            Modal = true,
        });
    }

    private async Task AddPatientDialog()
    {
        UserWithValidationModel user = new()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty,
            Address = string.Empty,
            UserName = string.Empty,
            CreatedOn = DateTime.UtcNow
        };
        await DialogService.ShowDialogAsync<AddPatientDialog>(user, new DialogParameters()
        {
            Title = $"Create new member",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleAddDialog(result)),
            Width = "700px",
            Height = "500px",
            TrapFocus = true,
            Modal = true,
            PrimaryActionEnabled = false
        });
    }

    private async Task EditPatientDialog(UserWithPaymentModel userInfo)
    {
        await DialogService.ShowDialogAsync<EditPatientDialog>(userInfo, new DialogParameters()
        {
            Title = $"Edit {userInfo.FirstName} {userInfo.LastName}",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleEditDialog(result)),
            Width = "700px",
            Height = "500px",
            TrapFocus = true,
            Modal = true,
        });
    }

    async Task UploadExcelDialog()
    {
        var data = new UploadExcelFileModel();
        await DialogService.ShowDialogAsync<UploadExcelDialog>(data, new DialogParameters()
        {
            Title = $"Import excel",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleExcelDialog(result)),
            Width = "500px",
            Height = "500px",
            TrapFocus = true,
            Modal = true,
        });
    }

    #region [ Dialog Handle ]
    private async Task HandleAddDialog(DialogResult result)
    {
        if (result.Cancelled)
            return;

        if (result.Data is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough required information");
            return;
        }

        UserWithValidationModel? user = result.Data as UserWithValidationModel;

        if (user is null || user.Email is null || user.PhoneNumber is null || user.FirstName is null || user.UserName is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough required information");
            return;
        }

        SignUpRecord dto = new( user.UserName, "Welkom112!!@",
                                user.FirstName, user.LastName,
                                user.Email, user.PhoneNumber, new string[] { "Patient" });

        await AuthenticationService.Register(dto, nameof(HandleAddDialog), new());
        await RefreshAsync();
        ToastService.ShowToast(ToastIntent.Success, $"User {user.UserName} added !!!");
    }

    private async Task HandleEditDialog(DialogResult result)
    {
        if (result.Cancelled)
            return;

        if (result.Data is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough required information");
            return;
        }

        UserWithValidationModel? user = result.Data as UserWithValidationModel;

        if (user is null || user.Email is null || user.PhoneNumber is null || user.FirstName is null || user.UserName is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough required information");
            return;
        }

        var userInfo = await ISContext.Users.UpdateAsync(user);
        if (userInfo is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "User not found in database, maybe it was deleted already.");
            return;
        }

        await RefreshAsync();
        ToastService.ShowToast(ToastIntent.Success, $"User {user.UserName} added !!!");
    }

    private async Task HandleExcelDialog(DialogResult result)
    {
        if (result.Cancelled)
            return;

        if (result.Data is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough information to create an expense");
            return;
        }

        var file = result.Data as UploadExcelFileModel;
        if (file == null)
            return;

        foreach (var user in file.Users)
            await ISContext.Users.CreateAsync(user);

        await this.RefreshAsync();
    }
    #endregion
    #endregion

    #region [ Appearance ]
    private Appearance PageButtonAppearance(int pageIndex)
        => State.CurrentPage == pageIndex ? Appearance.Accent : Appearance.Neutral;

    private PresenceStatus StatusConverter(bool isFullyPaid)
        => isFullyPaid ? PresenceStatus.Available : PresenceStatus.Busy;

    private string StatusTextConverter(bool isFullyPaid)
        => isFullyPaid ? "Fully Paid" : "Not Fully Paid";

    async Task HandleTextFilterInput()
        => await RefreshAsync(State.CurrentPage, State.LastNameFilter, State.StreetFilter);

    async void ClearFormats()
    {
        State.LastNameFilter = string.Empty;
        State.StreetFilter = string.Empty;
        await RefreshAsync(State.CurrentPage, State.LastNameFilter, State.StreetFilter);
    }

    private async Task CopyToClipboard(string text)
    {
        await JSRuntime.InvokeVoidAsync("clipboardInterop.copyText", text);
        ToastService.ShowToast(ToastIntent.Success, "Copied to clipboard");
    }
    #endregion

    #region [ Excel ]
    byte[] GenerateExcel(List<UserWithPaymentModel> users)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = spreadsheetDocument.WorkbookPart!.Workbook.AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"  // You can customize the sheet name here
                };

                Row headerRow = new Row() { RowIndex = 1 };
                sheetData.Append(headerRow);

                // Add header cells
                //Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("User Name"), DataType = CellValues.String };
                //headerRow.Append(header1);
                //Cell header2 = new Cell() { CellReference = "B1", CellValue = new CellValue("First Name"), DataType = CellValues.String };
                //headerRow.Append(header2);
                //Cell header3 = new Cell() { CellReference = "C1", CellValue = new CellValue("Last Name"), DataType = CellValues.String };
                //headerRow.Append(header3);
                //Cell header4 = new Cell() { CellReference = "F1", CellValue = new CellValue("Address"), DataType = CellValues.String };
                //headerRow.Append(header4);
                //Cell header5 = new Cell() { CellReference = "G1", CellValue = new CellValue("Email"), DataType = CellValues.String };
                //headerRow.Append(header5);

                headerRow.Append(new Cell[] 
                { 
                    new Cell() { CellReference = "A1", CellValue = new CellValue("User Name"), DataType = CellValues.String },
                    new Cell() { CellReference = "B1", CellValue = new CellValue("First Name"), DataType = CellValues.String },
                    new Cell() { CellReference = "C1", CellValue = new CellValue("Last Name"), DataType = CellValues.String },
                    new Cell() { CellReference = "F1", CellValue = new CellValue("Address"), DataType = CellValues.String },
                    new Cell() { CellReference = "G1", CellValue = new CellValue("Email"), DataType = CellValues.String }
                });

                // Add user data
                foreach (var user in users)
                {
                    Row dataRow = new Row();
                    //dataRow.Append(CreateTextCell(user.UserName ?? string.Empty));
                    //dataRow.Append(CreateTextCell(user.FirstName ?? string.Empty));
                    //dataRow.Append(CreateTextCell(user.LastName ?? string.Empty));
                    //dataRow.Append(CreateTextCell(user.Address ?? string.Empty));
                    //dataRow.Append(CreateTextCell(user.Email ?? string.Empty));
                    dataRow.Append(new Cell[]
                    {
                        CreateTextCell(user.UserName ?? string.Empty),
                        CreateTextCell(user.FirstName ?? string.Empty),
                        CreateTextCell(user.LastName ?? string.Empty),
                        CreateTextCell(user.Address ?? string.Empty),
                        CreateTextCell(user.Email ?? string.Empty)
                    });
                    sheetData.AppendChild(dataRow);
                }

                // Append the sheet to the workbook
                sheets.Append(sheet);

                workbookPart.Workbook.Save();
            }

            return stream.ToArray();
        }
    }

    private Cell CreateTextCell(string text)
    {
        return new Cell(new CellValue(text))
        {
            DataType = new EnumValue<CellValues>(CellValues.String)
        };
    }

    private Cell CreateNumberCell(string number)
    {
        return new Cell(new CellValue(number))
        {
            DataType = new EnumValue<CellValues>(CellValues.Number)
        };
    }

    async Task DownloadExcel()
    {
        if (State.UserWithPayments is null)
            return;

        string fileName = "HMS patient payment";
        byte[] excelData = GenerateExcel(State.UserWithPayments);
        await JSRuntime.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(excelData),
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
    #endregion

    #region [ Refresh Data ]
    private async Task RefreshAsync(int currentPage = 1,
                                    string lastNameFilter = "",
                                    string streetFilter = "")
    {
        await LoadDataAsync();

        var userResult = State.Users;
        var billResult = State.Bills;

        var usersData = userResult
            .GroupJoin(billResult, user => user.Id, bill => bill.MedicalExamEpisodeDTO!.MedicalExamDTO!.BookingAppointmentDTO!.PatientId,
                (user, userBills) => new UserWithPaymentModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    CreatedOn = user.CreatedOn,
                    IsFullyPaid = !userBills.Any(x => x.PaidDate == null),
                    Bills = userBills.ToArray()
                })
            .OrderByDescending(user => user.CreatedOn);

        State.UserWithPayments = usersData.Skip((currentPage - 1) * State.ItemsPerPage)
                                          .Take(State.ItemsPerPage).ToList();

        this.StateHasChanged();
    }
    #endregion

    #region [ LoadData ]
    private async Task LoadDataAsync()
    {
        State.Users.Clear();
        State.Bills.Clear();
        State.CurrentPage = 1;
        State.PaginationCount = [];
        State.ItemsPerPage = 15;

        var users = await ISContext.Users.GetUsersInRoleAsync("Admin");

        var bills = await HMSContext.Bills.GetBillByMultipleUserIdAsync(State.Users.Select(x => x.Id).ToArray(), true);

        State.Users = users.ToList();

        foreach (var bill in bills)
        {
            var analysisTestIds = bill.MedicalExamEpisodeDTO!.AnalysisTestDTOs!.Select(x => x.Id).ToArray();
            var analysisTests = await HMSContext.AnalysisTests.GetMultipleByIdIncludeServiceAsync(analysisTestIds);
            State.AnalysisTests = analysisTests.ToList();

            var drugPrescriptionIds = bill.MedicalExamEpisodeDTO!.DrugPrescriptionDTOs!.Select(x => x.Id).ToArray();
            var drugPrescriptions = await HMSContext.DrugPrescriptions.GetMultipleByIdIncludeDrugAsync(drugPrescriptionIds);
            State.DrugPrescriptions = drugPrescriptions.ToList();

            var roomAllocationIds = bill.MedicalExamEpisodeDTO!.RoomAllocationDTOs!.Select(x => x.Id).ToArray();
            var roomAllocations = await HMSContext.RoomAllocations.GetMultipleByIdIncludeRoomAsync(roomAllocationIds);
            State.RoomAllocations = roomAllocations.ToList();

            var updatedMedicalExamEpisodeDTO = bill.MedicalExamEpisodeDTO with
            {
                AnalysisTestDTOs = State.AnalysisTests,
                DrugPrescriptionDTOs = State.DrugPrescriptions,
                RoomAllocationDTOs = State.RoomAllocations
            };

            var updatedBill = bill with { MedicalExamEpisodeDTO = updatedMedicalExamEpisodeDTO };

            State.Bills.Add(updatedBill);
        }

        int paginationCount = (int)Math.Ceiling((double)State.Users.Count / State.ItemsPerPage);

        State.PaginationCount = Enumerable.Range(1, paginationCount).ToArray();

        var medicalExamEpisodes = bills.Select(x => x.MedicalExamEpisodeDTO);

        this.StateHasChanged();
    }
    #endregion
    #endregion
}
