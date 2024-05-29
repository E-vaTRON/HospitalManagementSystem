namespace HospitalManagementSystem.Blazor;

public partial class Home : AuthenticationComponentBase
{
    #region [ Properties - Inject ]
    [Inject]
    public IUserServiceProvider UserServiceProvider { get; set; }

    protected HomeState State { get; private set; }
    #endregion


    #region [ Properties - Parameter ]
    [Parameter]
    public BarChart BarChart { get; set; } = default!;

    private LineChart LineChart = default!;
    private DoughnutChart DoughnutChart = default!;
    private DoughnutChartOptions DoughnutChartOptions = default!;
    private ChartData ChartData = default!;
    private ChartData LineChartData = default!;
    #endregion

    #region [ Properties ]
    Option<string> SelectedYear = new Option<string>()
    {
        Value = (DateTime.Now.Year).ToString(),
        Text = (DateTime.Now.Year).ToString(),
        Selected = true
    };

    //IEnumerable<BillWithServicesDTO>? BillsWithServices;
    List<Option<string>> YearOptions;
    //List<Service>? Services;
    List<string>? MonthlyList;

    private Random random = new();

    #endregion

    #region [ CTor ]
    public Home(NavigationManager navigator) : base(navigator)
    {
    }
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
            if (await base.IsNotLogin())
            {
                base.Navigator.NavigateTo("/login", replace: true);
                return;
            }
            await RefreshAsync();
        }

    }

    #endregion

    #region [ Methods ]

    private async Task RefreshAsync()
    {
        await RenderYearlyBillAsync();
        await RenderExpensesChartAsync();
        
        StateHasChanged();
    }

    private async Task RenderYearlyBillAsync()
    {
        LineChartData = new ChartData
        {
            Labels = MonthlyList,
            Datasets = new List<IChartDataset>()
        };

        var options = CreateBarChartOptions();
    }

    private async Task UpdateYearlyBillAsync()
    {
        if (LineChartData is null || LineChartData.Datasets is null || !LineChartData.Datasets.Any()) return;
        var newDatasets = new List<IChartDataset>();

        //foreach (var service in Services)
        //{
        //    var barChartDataset = new BarChartDataset
        //    {
        //        Label = service.Name,
        //        Data = new List<double>()
        //    };

        //    for (int i = 1; i <= 12; i++)
        //    {
        //        var monthlyAmount = GetMonthlyBillAmount(service.Id.ToString(), i, Int32.Parse(selectedYear.Text ?? "2023"));
        //        barChartDataset.Data.Add(monthlyAmount);
        //    }

        //    barChartDataset.BackgroundColor = new List<string> { service.Color };
        //    barChartDataset.CategoryPercentage = 0.8;
        //    barChartDataset.BarPercentage = 1;

        //    newDatasets.Add(barChartDataset);
        //}

        LineChartData.Datasets = newDatasets;
        var options = CreateBarChartOptions();

        await BarChart.UpdateAsync(LineChartData, options);
    }

    private BarChartOptions CreateBarChartOptions()
    {
        var options = new BarChartOptions();

        // Interaction
        options.Interaction.Mode = InteractionMode.Index;

        // Title
        options.Plugins.Title.Text = "Services cost over 12 months";
        options.Plugins.Title.Color = "White";
        options.Plugins.Title.Display = true;
        options.Plugins.Title.Font.Size = 20;

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

    private double GetMonthlyBillAmount(string serviceId, int month, int year)
    {
        return 0;
    }

    //private List<Option<string>> InitYearlyComboBoxOptions(IEnumerable<BillWithServicesDTO>? billsWithServices)
    //{
    //    var uniqueYears = BillsWithServices
    //        ?.Select(bill => bill.CreatedDate.Year)
    //        .Distinct()
    //        .OrderByDescending(year => year)
    //        .ToList() ?? new List<int>();

    //    return uniqueYears
    //        .Select(year => new Option<string>
    //        {
    //            Value = year.ToString(),
    //            Text = year.ToString(),
    //            Selected = year == DateTime.Now.Year
    //        })
    //        .ToList();
    //}

    private async Task RenderExpensesChartAsync()
    {
        //var expenses = await expensesRepository.FindAll(x => x.IsDeleted == false).ToListAsync();

        //// Calculate total amount
        //decimal totalAmount = expenses.Sum(e => e.Quantity * e.Price);
        //expensesAmount = totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));

        //// Create chart data
        //chartData = new ChartData
        //{
        //    Labels = expenses.Select(e => e.Description).ToList()!,
        //    Datasets = new List<IChartDataset>
        //    {
        //        new DoughnutChartDataset
        //        {
        //            Data = expenses.Select(e => Math.Round((e.Quantity * e.Price) / totalAmount * 100, 2))
        //                           .ToList()
        //                           .ConvertAll(d => (double)d),
        //            BackgroundColor = ColorBuilder.CategoricalTwelveColors
        //                                          .Take(expenses.Count)
        //                                          .ToList(),
        //        }
        //    }
        //};

        //// Configure chart options
        //doughnutChartOptions = new DoughnutChartOptions
        //{
        //    Responsive = true,
        //    Plugins = new()
        //    {
        //        Title = new()
        //        {
        //            Text = "Expenses Distribution",
        //            Display = true,
        //            Color = "white"
        //        }
        //    }
        //};

        //// Initialize the chart
        //await doughnutChart.InitializeAsync(chartData, doughnutChartOptions);
    }
    #endregion
}
