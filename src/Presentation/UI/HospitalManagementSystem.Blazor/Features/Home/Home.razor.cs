namespace HospitalManagementSystem.Blazor;

public partial class Home
{
    #region [ Properties - Inject ]
    [Inject]
    public ISServiceContext ISContext { get; set; } = default!;

    [Inject]
    public HMSServiceContext HMSContext { get; set; } = default!;
    #endregion

    #region [ Properties ]
    protected HomeState State { get; private set; } = null!;
    #endregion

    #region [ Overrides ]
    protected override async Task OnInitializedAsync()
    {
        this.State = new HomeState();
        await base.OnInitializedAsync();

    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            //if (await base.IsNotLogin())
            //{
            //    base.Navigator.NavigateTo("/login", replace: true);
            //    return;
            //}
            await LoadDataAsync();
        }

    }

    #endregion

    #region [ Methods ]
    #region [ Price - Calculation ]
    private string PriceInTotal()
    {
        decimal totalAmount = 0;

        State.ModifiedBills!.ForEach(bill =>
        {
            totalAmount = CalculateAmountPerBill(bill);
        });

        return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
    }

    private string PricePerBill(HomeBillWithServicesModel bill)
    {
        var totalAmount = CalculateAmountPerBill(bill);
        return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
    }

    private decimal CalculateAmountPerBill(HomeBillWithServicesModel bill)
    {
        decimal totalAmount = 0;

        foreach (var analysisTest in bill.Episode!.AnalysisTestDTOs!)
        {
            if (analysisTest.DeviceServiceDTO != null)
            {
                totalAmount += analysisTest.DeviceServiceDTO.ServiceDTO!.ServicePrice;
            }
        }

        foreach (var drugPrescription in bill.Episode!.DrugPrescriptionDTOs!)
        {
            if (drugPrescription.DrugInventoryDTO != null)
            {
                totalAmount += drugPrescription.DrugInventoryDTO.DrugDTO!.UnitPrice * drugPrescription.Amount;
            }
        }

        foreach (var roomAllocation in bill.Episode!.RoomAllocationDTOs!)
        {
            if (roomAllocation.RoomDTO != null)
            {
                totalAmount += roomAllocation.RoomDTO.PricePerHour * (roomAllocation.EndTime - roomAllocation.StartTime).Hours;
            }
        }

        return totalAmount;
    }

    private decimal CalculateTotalService()
    {
        decimal totalAmount = 0;
        State.ModifiedBills!.ForEach(bill =>
        {
            foreach (var analysisTest in bill.Episode!.AnalysisTestDTOs!)
            {
                if (analysisTest.DeviceServiceDTO != null)
                {
                    totalAmount += analysisTest.DeviceServiceDTO.ServiceDTO!.ServicePrice;
                }
            }
        });
        return totalAmount;
    }

    //private decimal CalculateAmountPerService()
    //{
    //    decimal totalAmount = 0;
    //    State.ModifiedBills!.ForEach(bill =>
    //    {
    //        foreach (var analysisTest in bill.Episode!.AnalysisTestDTOs!)
    //        {
    //            if (analysisTest.DeviceServiceDTO != null)
    //            {
    //                totalAmount += analysisTest.DeviceServiceDTO.ServiceDTO!.ServicePrice;
    //            }
    //        }
    //    });
    //    return totalAmount;
    //}

    private decimal CalculateTotalRoomUsed()
    {
        decimal totalAmount = 0;
        State.ModifiedBills!.ForEach(bill =>
        {
            foreach (var roomAllocation in bill.Episode!.RoomAllocationDTOs!)
            {
                if (roomAllocation.RoomDTO != null)
                {
                    totalAmount += roomAllocation.RoomDTO.PricePerHour * (roomAllocation.EndTime - roomAllocation.StartTime).Hours;
                }
            }
        });
        return totalAmount;
    }

    private decimal CalculateTotalDrug()
    {
        decimal totalAmount = 0;
        State.ModifiedBills!.ForEach(bill =>
        {
            foreach (var drugPrescription in bill.Episode!.DrugPrescriptionDTOs!)
            {
                if (drugPrescription.DrugInventoryDTO != null)
                {
                    totalAmount += drugPrescription.DrugInventoryDTO.DrugDTO!.UnitPrice * drugPrescription.Amount;
                }
            }
        });
        return totalAmount;
    }
    #endregion

    #region [ UI Render ]
    private List<Option<string>> CreateYearComboBoxOptions(IEnumerable<HomeBillWithServicesModel>? billsWithServices)
    {
        var uniqueYears = billsWithServices
            ?.Select(bill => bill.CreatedOn.Year)
            .Distinct()
            .OrderByDescending(year => year)
            .ToList() ?? new List<int>();

        return uniqueYears
            .Select(year => new Option<string>
            {
                Value = year.ToString(),
                Text = year.ToString(),
                Selected = year == DateTime.Now.Year
            })
            .ToList();
    }

    private BarChartOptions CreateBarChartOptions()
    {
        var options = new BarChartOptions();

        // Interaction
        options.Interaction.Mode = InteractionMode.Index;

        // Title
        options.Plugins.Title!.Text = "Services cost over 12 months";
        options.Plugins.Title.Color = "White";
        options.Plugins.Title.Display = true;
        options.Plugins.Title.Font!.Size = 20;

        // Responsive
        options.Responsive = true;

        // X-Axis
        options.Scales.X!.Title!.Text = "Months";
        options.Scales.X.Title.Color = "White";
        options.Scales.X.Title.Display = true;

        // Y-Axis
        options.Scales.Y!.Title!.Text = "Amount 💵";
        options.Scales.Y.Title.Color = "White";
        options.Scales.Y.Title.Display = true;

        return options;
    }

    private void RenderYearBillAsync()
    {
        State.LineChartData = new ChartData
        {
            Labels = State.MonthlyList,
            Datasets = new List<IChartDataset>()
        };

        foreach (var service in State.ModifiedServices)
        {
            var barChartDataset = new BarChartDataset
            {
                Label = service.Name,
                Data = new List<double>()
            };

            foreach (var month in Enumerable.Range(1, 12))
            {
                var monthlyAmount = GetMonthlyBillAmount(service.Id.ToString(), month, Int32.Parse(State.SelectedYear.Text ?? "2023"));
                barChartDataset.Data.Add(monthlyAmount);
            }

            barChartDataset.CategoryPercentage = 0.8;
            barChartDataset.BarPercentage = 1;

            State.LineChartData.Datasets.Add(barChartDataset);
        }

        var options = CreateBarChartOptions();

        State.BarChart.InitializeAsync(State.LineChartData, options).GetAwaiter();
    }

    private void RenderServiceChartAsync()
    {
        // Create chart data
        State.ChartData = new ChartData
        {
            Labels = State.ModifiedServices.Select(e => e.Name).ToList()!,
            Datasets = new List<IChartDataset>
            {
                new DoughnutChartDataset
                {
                    Data = State.ModifiedServices.Select(service => Math.Round((service.AnalysisTextAmount) / CalculateTotalService() * 100, 2))
                                                 .ToList()
                                                 .ConvertAll(d => (double)d),
                    BackgroundColor = ColorBuilder.CategoricalTwelveColors
                                                  .Take(State.ModifiedServices.Count)
                                                  .ToList(),
                }
            }
        };

        // Configure chart options
        State.DoughnutChartOptions = new DoughnutChartOptions
        {
            Responsive = true,
            Plugins = new()
            {
                Title = new()
                {
                    Text = "Expenses Distribution",
                    Display = true,
                    Color = "white"
                }
            }
        };

        // Initialize the chart
        State.DoughnutChart.InitializeAsync(State.ChartData, State.DoughnutChartOptions).GetAwaiter();
    }

    #region [ UI Update ]
    private void UpdateYearBillAsync()
    {
        if (State.LineChartData is null || State.LineChartData.Datasets is null || !State.LineChartData.Datasets.Any())
            return;

        var newDatasets = new List<IChartDataset>();

        foreach (var service in State.ModifiedServices)
        {
            var barChartDataset = new BarChartDataset
            {
                Label = service.Name,
                Data = new List<double>()
            };

            foreach (var month in Enumerable.Range(1, 12))
            {
                var monthlyAmount = GetMonthlyBillAmount(service.Id.ToString(), month, Int32.Parse(State.SelectedYear.Text ?? "2023"));
                barChartDataset.Data.Add(monthlyAmount);
            }
            barChartDataset.CategoryPercentage = 0.8;
            barChartDataset.BarPercentage = 1;

            newDatasets.Add(barChartDataset);
        }

        State.LineChartData.Datasets = newDatasets;
        var options = CreateBarChartOptions();

        State.BarChart.UpdateAsync(State.LineChartData, options).GetAwaiter();
    }
    #endregion
    #endregion

    // ????
    private double GetMonthlyBillAmount(string serviceId, int month, int year)
    {
        return 0;
    }

    #region [ Refresh Data ]
    private void RefreshData()
    {
        State.ModifiedBills.Clear();
        State.ModifiedServices.Clear();

        var billsData = State.Bills
            .Select(bill => new HomeBillWithServicesModel
            {
                Id = bill.Id,
                Deadline = bill.Deadline,
                PaidDate = bill.PaidDate,
                ExcessAmount = bill.ExcessAmount,
                UnderPaidAmount = bill.UnderPaidAmount,
                CreatedOn = bill.CreatedOn,
                Services = bill.MedicalExamEpisodeDTO!.AnalysisTestDTOs!
                            .Select(test => test.DeviceServiceDTO!.ServiceDTO!).ToList(),
                Drugs = bill.MedicalExamEpisodeDTO!.DrugPrescriptionDTOs!
                            .Select(prescription => new DrugWithAmount
                            {
                                GoodName = prescription.DrugInventoryDTO!.DrugDTO!.GoodName,
                                ActiveIngredientName = prescription.DrugInventoryDTO!.DrugDTO!.ActiveIngredientName,
                                Unit = prescription.DrugInventoryDTO!.DrugDTO!.Unit,
                                UnitPrice = prescription.DrugInventoryDTO!.DrugDTO!.UnitPrice,
                                HealthInsurancePrice = prescription.DrugInventoryDTO!.DrugDTO!.HealthInsurancePrice,
                                Amount = prescription.Amount
                            }).ToList(),
                Rooms = bill.MedicalExamEpisodeDTO!.RoomAllocationDTOs!
                            .Select(roomAllocation => new RoomWithTime
                            {
                                Name = roomAllocation.RoomDTO!.Name,
                                PricePerHour = roomAllocation.RoomDTO!.PricePerHour,
                                RoomType = roomAllocation.RoomDTO!.RoomType,
                                StartTime = roomAllocation.StartTime,
                                EndTime = roomAllocation.EndTime
                            })
                            .ToList(),
                Episode = bill.MedicalExamEpisodeDTO!
            })
            .OrderByDescending(user => user.CreatedOn);

        State.ModifiedBills = billsData.ToList();

        var servicesData = State.Services
            .Select(service => new HomeServiceWithAmountModel
            {
                Id = service.Id,
                Name = service.Name,
                Unit = service.Unit,
                UnitPrice = service.UnitPrice,
                ServicePrice = service.ServicePrice,
                HealthInsurancePrice = service.HealthInsurancePrice,
                AnalysisTextAmount = service.DeviceServiceDTOs!.Sum(deviceService => deviceService.AnalysisTestDTOs!.Count)
            });

        State.ModifiedServices = servicesData.ToList();

        DateTime startDate = new DateTime(int.Parse(State.SelectedYear.Text!), 1, 1);

        State.YearOptions = CreateYearComboBoxOptions(State.ModifiedBills);
        State.MonthlyList = Enumerable.Range(0, 12)
                                      .Select(i => startDate.AddMonths(i).ToString("MMMM yyyy"))
                                      .ToList();


        RenderYearBillAsync();
        RenderServiceChartAsync();

        StateHasChanged();
    }
    #endregion

    #region [ Load Data ]
    private async Task LoadDataAsync()
    {
        State.Bills.Clear();
        State.Services.Clear();

        var users = await ISContext.Users.GetUsersInRoleAsync("Admin");

        var bills = await HMSContext.Bills.GetBillByMultipleUserIdAsync(users.Select(x => x.Id).ToArray(), true);

        var analysisTests = await HMSContext.AnalysisTests.GetAllIncludeServiceAsync();
        var deviceServices = analysisTests.Select(analysis => analysis.DeviceServiceDTO!).Distinct().ToList();

        var services = analysisTests.GroupBy(analysis => analysis.DeviceServiceDTO!.ServiceDTO!) // Group by Service
                                    .Select(group => group.Key) // Select distinct services
                                    .ToList();
        foreach (var service in services)
        {
            var deviceServiceIds = service.DeviceServiceDTOs!.Select(x => x.Id).ToArray();
            var deviceServiceServices = deviceServices.Where(deviceService => deviceServiceIds.Contains(deviceService.Id)).ToList();

            foreach (var deviceService in deviceServiceServices)
            {
                deviceService.AnalysisTestDTOs!.Clear();
                var analysis = analysisTests.Where(analysis => analysis.DeviceServiceDTO!.Id.Equals(deviceService.Id));
                foreach (var item in analysis)
                {
                    deviceService.AnalysisTestDTOs.Add(item);
                }
            }
            State.Services.Add(service);
        }


        var drugPrescriptions = await HMSContext.DrugPrescriptions.GetAllIncludeDrugAsync();
        var roomAllocations = await HMSContext.RoomAllocations.GetAllIncludeRoomAsync();

        foreach (var bill in bills)
        {
            var analysisTestIds = bill.MedicalExamEpisodeDTO!.AnalysisTestDTOs!.Select(x => x.Id).ToArray();
            var analysisTestBills = analysisTests.Where(analysisTest => analysisTestIds.Contains(analysisTest.Id));

            var drugPrescriptionIds = bill.MedicalExamEpisodeDTO!.DrugPrescriptionDTOs!.Select(x => x.Id).ToArray();
            var drugPrescriptionBills = drugPrescriptions.Where(drugPrescription => drugPrescriptionIds.Contains(drugPrescription.Id));

            var roomAllocationIds = bill.MedicalExamEpisodeDTO!.RoomAllocationDTOs!.Select(x => x.Id).ToArray();
            var roomAllocationBills = roomAllocations.Where(roomAllocation => roomAllocationIds.Contains(roomAllocation.Id));

            var updatedMedicalExamEpisodeDTO = bill.MedicalExamEpisodeDTO with
            {
                AnalysisTestDTOs = analysisTestBills.ToList(),
                DrugPrescriptionDTOs = drugPrescriptionBills.ToList(),
                RoomAllocationDTOs = roomAllocationBills.ToList()
            };

            var updatedBill = bill with { MedicalExamEpisodeDTO = updatedMedicalExamEpisodeDTO };

            State.Bills.Add(updatedBill);
        }

        RefreshData();

        this.StateHasChanged();
    }
    #endregion
    #endregion
}
