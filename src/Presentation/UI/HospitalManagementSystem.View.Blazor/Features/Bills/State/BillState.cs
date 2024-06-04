namespace HospitalManagementSystem.Blazor;

public class BillState : StateBase
{
    #region [ Fields ]
    private int     itemsPerPage;
    private int     currentPage;
    private int     progressBarMaxValue;
    private int     progressBarValue;
    private int[]   paginationCount;
    private string? paid;
    private string? percentage;
    private string? lastNameFilter;
    private string? amountRadioChoice;
    private string? createdDateRadioChoice;
    private string? deadlineRadioChoice;
    private List<OutputBillDTO>?                    bills;
    private List<OutputUserDTO>?                    users;
    //private Dictionary<string, OutputServiceDTO>?   services;
    //private Dictionary<string, DrugWithAmount>?     drugs;
    //private Dictionary<string, RoomWithTime>?       rooms;
    private List<OutputAnalysisTestDTO>?            analysisTests;
    private List<OutputDrugPrescriptionDTO>?        drugPrescriptions;
    private List<OutputRoomAllocationDTO>?          roomAllocations;
    //private List<InputServiceDTO>?                  selectedServices;
    //private List<InputDrugDTO>?                     selectedDrugs;
    //private List<InputRoomDTO>?                     selectedRooms;
    private List<BillWithUserAndServicesModel>?     modifiedBills;
    #endregion

    #region [ CTor ]
    public BillState()
    {
        paginationCount = [];
        bills = new List<OutputBillDTO>();
        users = new List<OutputUserDTO>();
        analysisTests = new List<OutputAnalysisTestDTO> { };
        drugPrescriptions = new List<OutputDrugPrescriptionDTO>();
        roomAllocations = new List<OutputRoomAllocationDTO>();
        //selectedServices = new List<InputServiceDTO>();
        //selectedDrugs = new List<InputDrugDTO>();
        //selectedRooms = new List<InputRoomDTO>();
        modifiedBills = new List<BillWithUserAndServicesModel> { };
    }
    #endregion

    #region [ Properties ]
    public int ItemsPerPage
    {
        get { return this.itemsPerPage!; }
        set { this.SetProperty(ref this.itemsPerPage, value); }
    }

    public int CurrentPage
    {
        get { return this.currentPage!; }
        set { this.SetProperty(ref this.currentPage, value); }
    }

    public int ProgressBarMaxValue
    {
        get { return this.progressBarMaxValue!; }
        set { this.SetProperty(ref this.progressBarMaxValue, value); }
    }

    public int ProgressBarValue
    {
        get { return this.progressBarValue!; }
        set { this.SetProperty(ref this.progressBarValue, value); }
    }

    public int[] PaginationCount
    {
        get { return this.paginationCount!; }
        set { this.SetProperty(ref this.paginationCount, value); }
    }

    public string Paid
    {
        get { return this.paid!; }
        set { this.SetProperty(ref this.paid, value); }
    }


    public string Percentage
    {
        get { return this.percentage!; }
        set { this.SetProperty(ref this.percentage, value); }
    }

    public string LastNameFilter
    {
        get { return this.lastNameFilter!; }
        set { this.SetProperty(ref this.lastNameFilter, value); }
    }

    public string AmountRadioChoice
    {
        get { return this.amountRadioChoice!; }
        set { this.SetProperty(ref this.amountRadioChoice, value); }
    }

    public string CreatedDateRadioChoice
    {
        get { return this.createdDateRadioChoice!; }
        set { this.SetProperty(ref this.createdDateRadioChoice, value); }
    }

    public string DeadlineRadioChoice
    {
        get { return this.deadlineRadioChoice!; }
        set { this.SetProperty(ref this.deadlineRadioChoice, value); }
    }

    public List<OutputBillDTO> Bills
    {
        get { return this.bills!; }
        set { this.SetProperty(ref this.bills, value); }
    }

    public List<OutputUserDTO> Users
    {
        get { return this.users!; }
        set { this.SetProperty(ref this.users, value); }
    }

    //public Dictionary<string, OutputServiceDTO> Services
    //{
    //    get { return this.services!; }
    //    set { this.SetProperty(ref this.services, value); }
    //}

    //public Dictionary<string, DrugWithAmount> Drugs
    //{
    //    get { return this.drugs!; }
    //    set { this.SetProperty(ref this.drugs, value); }
    //}

    //public Dictionary<string, RoomWithTime>? Rooms
    //{
    //    get { return this.rooms!; }
    //    set { this.SetProperty(ref this.rooms, value); }
    //}

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

    //public List<InputServiceDTO> SelectedServices
    //{
    //    get { return this.selectedServices!; }
    //    set { this.SetProperty(ref this.selectedServices, value); }
    //}

    //public List<InputDrugDTO> SelectedDrugs
    //{
    //    get { return this.selectedDrugs!; }
    //    set { this.SetProperty(ref this.selectedDrugs, value); }
    //}

    //public List<InputRoomDTO> SelectedRooms
    //{
    //    get { return this.selectedRooms!; }
    //    set { this.SetProperty(ref this.selectedRooms, value); }
    //}

    public List<BillWithUserAndServicesModel> ModifiedBills
    {
        get { return this.modifiedBills!; }
        set { this.SetProperty(ref this.modifiedBills, value); }
    }
    #endregion
}