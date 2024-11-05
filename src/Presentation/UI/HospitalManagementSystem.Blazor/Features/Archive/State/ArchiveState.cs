namespace HospitalManagementSystem.Blazor;

public class ArchiveState : StateBase
{
    #region [ Fields ]
    #region [ Page ]
    private int     itemsPerPage;
    private string? lastNameFilter;
    private string? amountRadioChoice;
    private string? createdDateRadioChoice;
    private string? deadlineRadioChoice;
    #endregion

    #region [ User ]
    private int                                 userCurrentPage;
    private int[]                               userPaginationCount;
    private List<OutputUserDTO>?                users;
    private List<ArchiveUserWithPoliciesModel>? modifiedUsers;
    #endregion

    #region [ Bill ]
    private int                             billCurrentPage;
    private string? paid; // ????
    private int[]                           billPaginationCount;
    private List<OutputBillDTO>?            bills;
    private List<ArchiveBillWithUserModel>? modifiedBills;
    #endregion

    #region [ Service ]
    private int                         serviceCurrentPage;
    private int[]                       servicePaginationCount;
    private List<OutputMedicalServiceDTO>?     services;
    private List<ArchiveServiceModel>?  modifiedServices;
    #endregion

    #region [ Drug ]
    private int                     drugCurrentPage;
    private int[]                   drugPaginationCount;
    private List<OutputDrugDTO>?    drugs;
    private List<ArchiveDrugModel>? modifiedDrugs;
    #endregion

    #region [ Room ]
    private int                     roomCurrentPage;
    private int[]                   roomPaginationCount;
    private List<OutputRoomDTO>?    rooms;
    private List<ArchiveRoomModel>? modifiedRooms;
    #endregion
    #endregion

    #region [ CTor ]
    public ArchiveState()
    {
        userPaginationCount = [];
        billPaginationCount = [];
        servicePaginationCount = [];
        drugPaginationCount = [];
        roomPaginationCount = [];
        bills = new List<OutputBillDTO>();
        users = new List<OutputUserDTO>();
        services = new List<OutputMedicalServiceDTO>();
        drugs = new List<OutputDrugDTO>();
        rooms = new List<OutputRoomDTO>();
        modifiedBills = new List<ArchiveBillWithUserModel>();
        modifiedUsers = new List<ArchiveUserWithPoliciesModel>();
        modifiedRooms = new List<ArchiveRoomModel>();
        modifiedServices = new List<ArchiveServiceModel>();
        modifiedDrugs = new List<ArchiveDrugModel>();
    }
    #endregion

    #region [ Properties ]
    public int ItemsPerPage
    {
        get { return this.itemsPerPage!; }
        set { this.SetProperty(ref this.itemsPerPage, value); }
    }

    public string Paid
    {
        get { return this.paid!; }
        set { this.SetProperty(ref this.paid, value); }
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

    #region [ User ]
    public int UserCurrentPage
    {
        get { return this.userCurrentPage!; }
        set { this.SetProperty(ref this.userCurrentPage, value); }
    }

    public int[] UserPaginationCount
    {
        get { return this.userPaginationCount!; }
        set { this.SetProperty(ref this.userPaginationCount, value); }
    }

    public List<OutputUserDTO> Users
    {
        get { return this.users!; }
        set { this.SetProperty(ref this.users, value); }
    }

    public List<ArchiveUserWithPoliciesModel> ModifiedUsers
    {
        get { return this.modifiedUsers!; }
        set { this.SetProperty(ref this.modifiedUsers, value); }
    }
    #endregion

    #region [ Bill ]
    public int BillCurrentPage
    {
        get { return this.billCurrentPage!; }
        set { this.SetProperty(ref this.billCurrentPage, value); }
    }

    public int[] BillPaginationCount
    {
        get { return this.billPaginationCount!; }
        set { this.SetProperty(ref this.billPaginationCount, value); }
    }

    public List<OutputBillDTO> Bills
    {
        get { return this.bills!; }
        set { this.SetProperty(ref this.bills, value); }
    }

    public List<ArchiveBillWithUserModel> ModifiedBills
    {
        get { return this.modifiedBills!; }
        set { this.SetProperty(ref this.modifiedBills, value); }
    }
    #endregion

    #region [ Service ]
    public int ServiceCurrentPage
    {
        get { return this.serviceCurrentPage!; }
        set { this.SetProperty(ref this.serviceCurrentPage, value); }
    }

    public int[] ServicePaginationCount
    {
        get { return this.servicePaginationCount!; }
        set { this.SetProperty(ref this.servicePaginationCount, value); }
    }

    public List<OutputMedicalServiceDTO> Services
    {
        get { return this.services!; }
        set { this.SetProperty(ref this.services, value); }
    }

    public List<ArchiveServiceModel> ModifiedServices
    {
        get { return this.modifiedServices!; }
        set { this.SetProperty(ref this.modifiedServices, value); }
    }
    #endregion

    #region [ Drug ]
    public int DrugCurrentPage
    {
        get { return this.drugCurrentPage!; }
        set { this.SetProperty(ref this.drugCurrentPage, value); }
    }

    public int[] DrugPaginationCount
    {
        get { return this.drugPaginationCount!; }
        set { this.SetProperty(ref this.drugPaginationCount, value); }
    }

    public List<OutputDrugDTO> Drugs
    {
        get { return this.drugs!; }
        set { this.SetProperty(ref this.drugs, value); }
    }

    public List<ArchiveDrugModel> ModifiedDrugs
    {
        get { return this.modifiedDrugs!; }
        set { this.SetProperty(ref this.modifiedDrugs, value); }
    }
    #endregion

    #region [ Room ]
    public int RoomCurrentPage
    {
        get { return this.roomCurrentPage!; }
        set { this.SetProperty(ref this.roomCurrentPage, value); }
    }

    public int[] RoomPaginationCount
    {
        get { return this.roomPaginationCount!; }
        set { this.SetProperty(ref this.roomPaginationCount, value); }
    }

    public List<OutputRoomDTO> Rooms
    {
        get { return this.rooms!; }
        set { this.SetProperty(ref this.rooms, value); }
    }

    public List<ArchiveRoomModel> ModifiedRooms
    {
        get { return this.modifiedRooms!; }
        set { this.SetProperty(ref this.modifiedRooms, value); }
    }

    #endregion

    #endregion
}
