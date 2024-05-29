namespace HospitalManagementSystem.Blazor;

public class HomeState : StateBase
{
    #region [ Fields ]
    private string? totalBillAmount;
    private string? collectionAmount;
    private string? expensesAmount;
    private string[]? backgroundColors;
    #endregion

    #region [ CTor ]
    public HomeState()
    {
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

    public string[] BackgroundColors
    {
        get { return this.backgroundColors!; }
        set { this.SetProperty(ref this.backgroundColors, value); }
    }
    #endregion
}
