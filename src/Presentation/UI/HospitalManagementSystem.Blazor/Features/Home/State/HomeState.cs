namespace HospitalManagementSystem.Blazor;

public class HomeState : StateBase
{
    #region [ Fields ]
    private string?     totalBillAmount;
    private string?     collectionAmount;
    private string?     expensesAmount;

    private BarChart?               barChart;
    private LineChart?              lineChart;
    private DoughnutChart?          doughnutChart;
    private DoughnutChartOptions?   doughnutChartOptions;
    private ChartData?              chartData;
    private ChartData?              lineChartData;

    private List<Option<string>>?           yearOptions;
    private Option<string>?                 selectedYear;
    private List<string>?                   monthlyList;
    private Random?                         random;
    private List<OutputMedicalServiceDTO>              services;
    private List<OutputBillDTO>                 bills;
    private List<HomeServiceWithAmountModel>    modifiedServices;
    private List<HomeBillWithServicesModel>?    modifiedBills;
    #endregion

    #region [ CTor ]
    public HomeState()
    {
        services = new List<OutputMedicalServiceDTO>();
        bills = new List<OutputBillDTO>();
        modifiedBills = new List<HomeBillWithServicesModel>() { };
        modifiedServices = new List<HomeServiceWithAmountModel>() { };
        yearOptions = new List<Option<string>>();
        selectedYear = new Option<string>()
        {
            Value = (DateTime.Now.Year).ToString(),
            Text = (DateTime.Now.Year).ToString(),
            Selected = true
        };
        monthlyList = new List<string>();
        random = new Random();

        barChart = default!;
        lineChart = default;
        doughnutChart = default;
        doughnutChartOptions = default!;
        chartData = default;
        lineChartData = default!;
    }
    #endregion

    #region [ Properties ]
    public string TotalBillAmount
    {
        get { return this.totalBillAmount!; }
        set { this.SetProperty(ref this.totalBillAmount, value); }
    }

    public string CollectionAmount
    {
        get { return this.collectionAmount!; }
        set { this.SetProperty(ref this.collectionAmount, value); }
    }

    public string ExpensesAmount
    {
        get { return this.expensesAmount!; }
        set { this.SetProperty(ref this.expensesAmount, value); }
    }

    public BarChart BarChart
    {
        get { return this.barChart!; }
        set { this.SetProperty(ref this.barChart, value); }
    }

    public LineChart LineChart
    {
        get { return this.lineChart!; }
        set { this.SetProperty(ref this.lineChart, value); }
    }

    public DoughnutChart DoughnutChart
    {
        get { return this.doughnutChart!; }
        set { this.SetProperty(ref this.doughnutChart, value); }
    }

    public DoughnutChartOptions DoughnutChartOptions
    {
        get { return this.doughnutChartOptions!; }
        set { this.SetProperty(ref this.doughnutChartOptions, value); }
    }

    public ChartData ChartData
    {
        get { return this.chartData!; }
        set { this.SetProperty(ref this.chartData, value); }
    }

    public ChartData LineChartData
    {
        get { return this.lineChartData!; }
        set { this.SetProperty(ref this.lineChartData, value); }
    }

    public List<OutputMedicalServiceDTO> Services
    {
        get { return this.services!; }
        set { this.SetProperty(ref this.services, value); }
    }

    public List<OutputBillDTO> Bills
    {
        get { return this.bills!; }
        set { this.SetProperty(ref this.bills, value); }
    }

    public List<HomeServiceWithAmountModel> ModifiedServices
    {
        get { return this.modifiedServices!; }
        set { this.SetProperty(ref this.modifiedServices, value); }
    }

    public List<HomeBillWithServicesModel> ModifiedBills
    {
        get { return this.modifiedBills!; }
        set { this.SetProperty(ref this.modifiedBills, value); }
    }

    public Option<string> SelectedYear
    {
        get { return this.selectedYear!; }
        set { this.SetProperty(ref this.selectedYear, value); }
    }

    public List<Option<string>> YearOptions
    {
        get { return this.yearOptions!; }
        set { this.SetProperty(ref this.yearOptions, value); }
    }

    public List<string> MonthlyList
    {
        get { return this.monthlyList!; }
        set { this.SetProperty(ref this.monthlyList, value); }
    }

    public Random Random
    {
        get { return this.random!; }
        set { this.SetProperty(ref this.random, value); }
    }
    #endregion
}
