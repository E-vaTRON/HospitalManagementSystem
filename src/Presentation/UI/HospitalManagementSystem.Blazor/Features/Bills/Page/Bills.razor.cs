﻿using System.Linq;

namespace HospitalManagementSystem.Blazor;

public partial class Bills : AuthenticationComponentBase
{
    #region [ Properties - Inject ]
    private BillState State { get; set; } = null!;

    [Inject]
    private HMSServiceContext HMSContext { get; set; } = default!;

    [Inject]
    private ISServiceContext ISContext { get; set; } = default!;
    #endregion

    #region [ CTor ]
    public Bills()
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
    #region [ Filter - Sort ]
    private void OnLastNameFilter(string searchTerm)
    {
        if (searchTerm.Length > 0 && !string.IsNullOrWhiteSpace(searchTerm))
        {
            var filtered = this.State.ModifiedBills.Where(x => x.User!.LastName.ToLower().Contains(searchTerm));
            this.OnFilterData(filtered);
        }
    }

    private void OnAmountSort(string sortTerm)
    {
        switch (sortTerm)
        {
            case "2":
                this.State.ModifiedBills = this.State.ModifiedBills.OrderBy(x => CalculateAmountPerBill(x)).ToList();
                break;
            case "3":
                this.State.ModifiedBills = this.State.ModifiedBills.OrderByDescending(x => CalculateAmountPerBill(x)).ToList();
                break;
            default:
                this.State.AmountRadioChoice = "1";
                break;
        }
    }

    private void OnCreatedDateSort(string sortTerm)
    {
        switch (sortTerm)
        {
            case "2":
                this.State.ModifiedBills = this.State.ModifiedBills.OrderBy(x => x.CreatedOn).ToList();
                break;
            case "3":
                this.State.ModifiedBills = this.State.ModifiedBills.OrderByDescending(x => x.CreatedOn).ToList();
                break;
            default:
                this.State.AmountRadioChoice = "1";
                break;
        }
    }

    private void OnDeadlineSort(string sortTerm)
    {
        switch (sortTerm)
        {
            case "2":
                this.State.ModifiedBills = this.State.ModifiedBills.OrderBy(x => x.Deadline).ToList();
                break;
            case "3":
                this.State.ModifiedBills = this.State.ModifiedBills.OrderByDescending(x => x.Deadline).ToList();
                break;
            default:
                this.State.AmountRadioChoice = "1";
                break;
        }
    }

    private void OnFilterData(IEnumerable<BillWithUserAndServicesModel> filtered)
    {
        this.State.ModifiedBills.Clear();
        this.State.ModifiedBills = filtered.ToList();
        this.StateHasChanged();
    }
    #endregion

    private async Task DeleteAsync(BillWithUserAndServicesModel bill)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Record {bill.Id} will be move to archive?",
                                                                "Yes", "No",
                                                                "Do you want to delete this record?");
        var result = await dialog.Result;
        if (result.Cancelled)
            return;

        await HMSContext.Bills.DeleteAsync(bill);

        await LoadDataAsync();
        ToastService.ShowToast(ToastIntent.Success, "Record deleted successfully.");
    }

    #region [ Price - Calculation ]
    private string PricePerBill(BillWithUserAndServicesModel bill)
    {
        var totalAmount = CalculateAmountPerBill(bill);
        return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
    }

    private decimal CalculateAmountPerBill(BillWithUserAndServicesModel bill)
    {
        decimal totalAmount = 0;

        foreach (var episodeService in bill.Episode!.ServiceEpisodes!)
        {
            if (episodeService.MedicalService != null)
            {
                totalAmount += episodeService.MedicalService!.ServicePrice;
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

    #region [ Dialogs ]
    private async Task OpenAddBillDialog()
    {
        BillWithSelectionModel bill = new()
        {
            UserSelectList = State.Users,
        };
        await DialogService.ShowDialogAsync<AddBillDialog>(bill, new DialogParameters()
        {
            Title = $"Create new bill",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleAddDialog(result)),
            Width = "450px",
            Height = "450px",
            TrapFocus = true,
            Modal = true,
            PrimaryActionEnabled = false
        });
    }

    private async Task OpenProcessBillDialog(BillWithUserAndServicesModel bill)
    {
        await DialogService.ShowDialogAsync<ProcessBillDialog>(bill, new DialogParameters()
        {
            Title = $"{bill.User!.LastName}",
            Alignment = HorizontalAlignment.Center,
            OnDialogResult = EventCallback.Factory.Create<DialogResult>(this, result => HandleEditBillDialog(result)),
            Width = "450px",
            Height = "520px",
            TrapFocus = true,
            Modal = true,
        });
    }

    #region [ Handle ]
    private async Task HandleAddDialog(DialogResult result)
    {
        if (result.Cancelled)
            return;

        if (result.Data is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough information to create a bill");
            return;
        }

        BillWithSelectionModel? bill = result.Data as BillWithSelectionModel;
        if (bill is null || bill.SelectedUser is null || bill.SelectedEpisode is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough information to create a bill");
            return;
        }

        InputBillDTO dto = new()
        {
            MedicalExamEpisodeDTOId = bill.MedicalExamEpisodeDTOId,
            Deadline = bill.Deadline,
            PaidDate = null,
            ExcessAmount = default!,
            UnderPaidAmount = default!,
            CreatedOn = DateTime.UtcNow
        };

        await HMSContext.Bills.AddAsync(dto);

        RefreshData();
        ToastService.ShowToast(ToastIntent.Success, "New bill created !!!");
    }

    private async Task HandleEditBillDialog(DialogResult result)
    {
        if (result.Cancelled)
            return;

        if (result.Data is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough information to create a bill");
            return;
        }

        BillWithSelectionModel? bill = result.Data as BillWithSelectionModel;
        if (bill is null || bill!.PaidDate is null)
        {
            ToastService.ShowToast(ToastIntent.Error, "Not enough information to create a payment");
            return;
        }

        await HMSContext.Bills.UpdateAsync(bill);

        RefreshData();
        ToastService.ShowToast(ToastIntent.Success, "Payment processed !!!");
    }
    #endregion
    #endregion

    #region [ Appearance ]
    private Appearance PageButtonAppearance(int pageIndex)
        => State.CurrentPage == pageIndex ? Appearance.Accent : Appearance.Neutral;

    void HandleTextFilterInput()
        => RefreshData(State.CurrentPage, State.LastNameFilter, State.AmountRadioChoice, State.CreatedDateRadioChoice, State.DeadlineRadioChoice);

    void SelectedChoice()
        => RefreshData(State.CurrentPage, State.LastNameFilter, State.AmountRadioChoice, State.CreatedDateRadioChoice, State.DeadlineRadioChoice);

    void ClearFormats()
    {
        State.LastNameFilter = string.Empty;
        State.AmountRadioChoice = "1";
        State.CreatedDateRadioChoice = "1";
        State.DeadlineRadioChoice = "1";
        RefreshData(State.CurrentPage, State.LastNameFilter, "1", "1", "1");
    }

    private async Task CopyToClipboard(string text)
    {
        await JSRuntime.InvokeVoidAsync("clipboardInterop.copyText", text);
        ToastService.ShowToast(ToastIntent.Success, "Copied to clipboard");
    }
    #endregion

    #region [ Excel ]
    byte[] GenerateExcel(ICollection<BillWithUserAndServicesModel> bills)
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
                headerRow.Append(new Cell[]
                {
                    new Cell() { CellReference = "A1", CellValue = new CellValue("User Episode"), DataType = CellValues.String },
                    new Cell() { CellReference = "B1", CellValue = new CellValue("Services"), DataType = CellValues.String },
                    new Cell() { CellReference = "C1", CellValue = new CellValue("Drug"), DataType = CellValues.String },
                    new Cell() { CellReference = "D1", CellValue = new CellValue("Room"), DataType = CellValues.String },
                    new Cell() { CellReference = "E1", CellValue = new CellValue("Created Date"), DataType = CellValues.String },
                    new Cell() { CellReference = "F1", CellValue = new CellValue("Deadline"), DataType = CellValues.String },
                    new Cell() { CellReference = "G1", CellValue = new CellValue("Amount"), DataType = CellValues.String }
                });

                // Add user data
                foreach (var bill in bills)
                {
                    Row dataRow = new Row();
                    //dataRow.Append(CreateTextCell(bill.User!.FirstName + " " + bill.User!.LastName + " " + (bill.Episode?.Id ?? string.Empty)));
                    //dataRow.Append(CreateTextCell(string.Join("\r\n ", bill.Services.Select(test => test.Name) ?? Enumerable.Empty<string>())));
                    //dataRow.Append(CreateTextCell(string.Join("\r\n", bill.Drugs.Select(drug => $"{drug.GoodName} ({drug.Amount})") ?? Enumerable.Empty<string>())));
                    //dataRow.Append(CreateTextCell(string.Join("\r\n", bill.Rooms.Select(room => $"{room.Name} Start: {room.StartTime} End: {room.EndTime}") ?? Enumerable.Empty<string>())));
                    //dataRow.Append(CreateTextCell(bill.CreatedOn.ToString("dd/MM/yy")));
                    //dataRow.Append(CreateTextCell(bill.Deadline.ToString("dd/MM/yy")));
                    //dataRow.Append(CreateTextCell(PricePerBill(bill)));

                    dataRow.Append(new Cell[]
                    {
                        CreateTextCell(bill.User!.FirstName + " " + bill.User!.LastName + " " + (bill.Episode?.Id ?? string.Empty)),
                        CreateTextCell(string.Join("\r\n ", bill.Services.Select(test => test.Name) ?? Enumerable.Empty<string>())),
                        CreateTextCell(string.Join("\r\n", bill.Drugs.Select(drug => $"{drug.GoodName} ({drug.Amount})") ?? Enumerable.Empty<string>())),
                        CreateTextCell(string.Join("\r\n", bill.Rooms.Select(room => $"{room.Name} Start: {room.StartTime} End: {room.EndTime}") ?? Enumerable.Empty<string>())),
                        CreateTextCell(bill.CreatedOn.ToString("dd/MM/yy")),
                        CreateTextCell(bill.Deadline.ToString("dd/MM/yy")),
                        CreateTextCell(PricePerBill(bill))

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
        if (State.ModifiedBills is null)
            return;

        string fileName = "HMS patient payment";
        byte[] excelData = GenerateExcel(State.ModifiedBills);
        await JSRuntime.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(excelData),
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
    #endregion

    #region [ Refresh Data ]
    private void RefreshData(int currentPage = 1,
                             string lastNameFilter = "",
                             string amountSorting = "1",
                             string createdDateSorting = "1",
                             string deadlineSorting = "1")
    {
        State.ModifiedBills.Clear();

        //var drugWithAmountList = State.Bills
        //    .SelectMany(bill => bill.MedicalExamEpisodeDTO!.DrugPrescriptionDTOs!
        //        .Select(prescription => new DrugWithAmount
        //        {
        //            GoodName = prescription.DrugInventoryDTO!.DrugDTO!.GoodName,
        //            ActiveIngredientName = prescription.DrugInventoryDTO!.DrugDTO!.ActiveIngredientName,
        //            Unit = prescription.DrugInventoryDTO!.DrugDTO!.Unit,
        //            UnitPrice = prescription.DrugInventoryDTO!.DrugDTO!.UnitPrice,
        //            HealthInsurancePrice = prescription.DrugInventoryDTO!.DrugDTO!.HealthInsurancePrice,
        //            Amount = prescription.Amount
        //        }))
        //    .ToList();

        //var roomWithTimeList = State.Bills
        //    .SelectMany(bill => bill.MedicalExamEpisodeDTO!.RoomAllocationDTOs!
        //        .Select(roomAllocation => new RoomWithTime
        //        {
        //            Name = roomAllocation.RoomDTO!.Name,
        //            PricePerHour = roomAllocation.RoomDTO!.PricePerHour,
        //            RoomType = roomAllocation.RoomDTO!.RoomType,
        //            StartTime = roomAllocation.StartTime,
        //            EndTime = roomAllocation.EndTime
        //        }))
        //    .ToList();

        var billsData = State.Bills
            .Join(State.Users,
                   bill => bill.MedicalExamEpisode!.MedicalExam!.BookingAppointment!.PatientId,
                   user => user.Id,
                   (bill, user) => new BillWithUserAndServicesModel
                   {
                       Id = bill.Id,
                       Deadline = bill.Deadline,
                       PaidDate = bill.PaidDate,
                       ExcessAmount = bill.ExcessAmount,
                       UnderPaidAmount = bill.UnderPaidAmount,
                       CreatedOn = bill.CreatedOn,
                       User = user,
                       Services = bill.MedicalExamEpisode!.ServiceEpisodes!
                                    .Select(test => test.MedicalService!).ToList(),
                       Drugs = bill.MedicalExamEpisode!.DrugPrescriptions!
                                    .Select(prescription => new DrugWithAmount
                                    {
                                        GoodName = prescription.DrugInventory!.Drug!.GoodName,
                                        ActiveIngredientName = prescription.DrugInventory!.Drug!.ActiveIngredientName,
                                        Unit = prescription.DrugInventory!.Drug!.Unit,
                                        UnitPrice = prescription.DrugInventory!.Drug!.UnitPrice,
                                        HealthInsurancePrice = prescription.DrugInventory!.Drug!.HealthInsurancePrice,
                                        Amount = prescription.Amount
                                    }).ToList(),
                       Rooms = bill.MedicalExamEpisode!.RoomAllocations!
                                    .Select(roomAllocation => new RoomWithTime
                                    {
                                        Name = roomAllocation.Room!.Name,
                                        PricePerHour = roomAllocation.Room!.PricePerHour,
                                        RoomType = roomAllocation.Room!.RoomType,
                                        StartTime = roomAllocation.StartTime,
                                        EndTime = roomAllocation.EndTime
                                    })
                                    .ToList(),
                       Episode = bill.MedicalExamEpisode!
                   })
            .OrderByDescending(user => user.CreatedOn);

        OnLastNameFilter(lastNameFilter);
        OnAmountSort(amountSorting);
        OnCreatedDateSort(createdDateSorting);
        OnDeadlineSort(deadlineSorting);

        State.ModifiedBills = billsData.Skip((currentPage - 1) * State.ItemsPerPage)
                                       .Take(State.ItemsPerPage).ToList();
        StateHasChanged();
    }
    #endregion

    #region [ Load Data ]
    private async Task LoadDataAsync()
    {
        State.Users.Clear();
        State.Bills.Clear();
        State.AnalysisTests.Clear();
        State.DrugPrescriptions.Clear();
        State.RoomAllocations.Clear();
        State.PaginationCount = [];

        var users = await ISContext.Users.GetUsersInRoleAsync("Admin");

        var bills = await HMSContext.Bills.GetBillByMultipleUserIdAsync(State.Users.Select(x => x.Id).ToArray(), true);

        //var analysisTests = await HMSContext.AnalysisTests.GetAllIncludeServiceAsync();
        var drugPrescriptions = await HMSContext.DrugPrescriptions.GetAllIncludeDrugAsync();
        var roomAllocations = await HMSContext.RoomAllocations.GetAllIncludeRoomAsync();

        State.Users = users.ToList();

        foreach (var bill in bills)
        {
            var analysisTestIds = bill.MedicalExamEpisode!.AnalysisTests!.Select(x => x.Id).ToArray();
            //var analysisTestBills = analysisTests.Where(analysisTest => analysisTestIds.Contains(analysisTest.Id));
            //State.AnalysisTests = analysisTestBills.ToList();

            var drugPrescriptionIds = bill.MedicalExamEpisode!.DrugPrescriptions!.Select(x => x.Id).ToArray();
            var drugPrescriptionBills = drugPrescriptions.Where(drugPrescription => drugPrescriptionIds.Contains(drugPrescription.Id));
            State.DrugPrescriptions = drugPrescriptionBills.ToList();

            var roomAllocationIds = bill.MedicalExamEpisode!.RoomAllocations!.Select(x => x.Id).ToArray();
            var roomAllocationBills = roomAllocations.Where(roomAllocation => roomAllocationIds.Contains(roomAllocation.Id));
            State.RoomAllocations = roomAllocationBills.ToList();

            var updatedMedicalExamEpisodeDTO = bill.MedicalExamEpisode with
            {
                AnalysisTests = State.AnalysisTests,
                DrugPrescriptions = State.DrugPrescriptions,
                RoomAllocations = State.RoomAllocations
            };

            var updatedBill = bill with { MedicalExamEpisode = updatedMedicalExamEpisodeDTO };

            State.Bills.Add(updatedBill);
        }

        int paginationCount = (int)Math.Ceiling((double)State.Bills
                                         .Where(x => x.PaidDate is null)
                                         .ToList().Count / State.ItemsPerPage);

        State.PaginationCount = Enumerable.Range(1, paginationCount).ToArray();

        //var medicalExamEpisodes = bills.Select(x => x.MedicalExamEpisodeDTO);

        RefreshData();

        this.StateHasChanged();
    }
    #endregion
    #endregion
}
