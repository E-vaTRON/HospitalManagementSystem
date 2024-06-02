namespace HospitalManagementSystem.Blazor;

public class PatientState : StateBase
{
    #region [ Fields ]
    private int         currentPage;
    private int         itemsPerPage;
    private int[]       paginationCount;
    private string?     lastNameFilter;
    private string?     addressFilter;
    private List<OutputUserDTO>?                users;
    private List<OutputBillDTO>?                bills;
    private List<OutputAnalysisTestDTO>?        analysisTests;
    private List<OutputDrugPrescriptionDTO>?    drugPrescriptions;
    private List<OutputRoomAllocationDTO>?      roomAllocations;
    private List<UserWithPaymentModel>?         modifiedUser;
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
        modifiedUser = new List<UserWithPaymentModel>();
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

    public string LastNameFilter
    {
        get { return this.lastNameFilter!; }
        set { this.SetProperty(ref this.lastNameFilter, value); }
    }

    public string AddressFilter
    {
        get { return this.addressFilter!; }
        set { this.SetProperty(ref this.addressFilter, value); }
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

    public List<UserWithPaymentModel> ModifiedUser
    {
        get { return this.modifiedUser!; }
        set { this.SetProperty(ref this.modifiedUser, value); }
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
