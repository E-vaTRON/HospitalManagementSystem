namespace HospitalManagementSystem.Blazor;

public class PatientState : StateBase
{
    #region [ Fields ]
    private int         currentPage;
    private int         itemsPerPage;
    private int[]       paginationCount;
    private string?     blockRadioChoice;
    private string?     phaseRadioChoice;
    private string?     lastNameFilter;
    private string?     streetFilter;
    private List<OutputUserDTO>?                users;
    private List<UserWithPaymentModel>?         userWithPayments;
    private List<OutputBillDTO>?                bills;
    private List<OutputAnalysisTestDTO>?        analysisTests;
    private List<OutputDrugPrescriptionDTO>?    drugPrescriptions;
    private List<OutputRoomAllocationDTO>?      roomAllocations;
    #endregion

    #region [ CTor ]
    public PatientState()
    {
        paginationCount = [];
        users = new List<OutputUserDTO>();
        bills = new List<OutputBillDTO>();
        analysisTests = new List<OutputAnalysisTestDTO>();
        drugPrescriptions = new List<OutputDrugPrescriptionDTO>();
        roomAllocations = new List<OutputRoomAllocationDTO>();
        userWithPayments = new List<UserWithPaymentModel>();
    }
    #endregion

    #region [ Properties ]
    public int CurrentPage
    {
        get { return this.currentPage!; }
        set { this.SetProperty(ref this.currentPage, value); }
    }

    public int ItemsPerPage
    {
        get { return this.itemsPerPage!; }
        set { this.SetProperty(ref this.itemsPerPage, value); }
    }

    public int[] PaginationCount
    {
        get { return this.paginationCount!; }
        set { this.SetProperty(ref this.paginationCount, value); }
    }

    public string BlockRadioChoice
    {
        get { return this.blockRadioChoice!; }
        set { this.SetProperty(ref this.blockRadioChoice, value); }
    }

    public string PhaseRadioChoice
    {
        get { return this.phaseRadioChoice!; }
        set { this.SetProperty(ref this.phaseRadioChoice, value); }
    }

    public string LastNameFilter
    {
        get { return this.lastNameFilter!; }
        set { this.SetProperty(ref this.lastNameFilter, value); }
    }

    public string StreetFilter
    {
        get { return this.streetFilter!; }
        set { this.SetProperty(ref this.streetFilter, value); }
    }

    public List<OutputUserDTO> Users
    {
        get { return this.users!; }
        set { this.SetProperty(ref this.users, value); }
    }

    public List<OutputBillDTO> Bills
    {
        get { return this.bills!; }
        set { this.SetProperty(ref this.bills, value); }
    }

    public List<UserWithPaymentModel> UserWithPayments
    {
        get { return this.userWithPayments!; }
        set { this.SetProperty(ref this.userWithPayments, value); }
    }

    public List<OutputAnalysisTestDTO> AnalysisTests
    {
        get { return this.analysisTests!; }
        set { this.SetProperty(ref this.analysisTests, value); }
    }

    public List<OutputDrugPrescriptionDTO> DrugPrescriptions
    {
        get { return this.drugPrescriptions!; }
        set { this.SetProperty(ref this.drugPrescriptions, value); }
    }

    public List<OutputRoomAllocationDTO> RoomAllocations
    {
        get { return this.roomAllocations!; }
        set { this.SetProperty(ref this.roomAllocations, value); }
    }
    #endregion
}
