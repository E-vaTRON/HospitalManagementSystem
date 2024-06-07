namespace HospitalManagementSystem.Blazor;

public class ServiceState : StateBase
{
     #region [ Fields ]
    private int         currentPage;
    private int         itemsPerPage;
    private int[]       paginationCount;
    private List<OutputServiceDTO>?             services;
    private List<ServiceWithDeviceModel>?       modifiedServices;
    #endregion

    #region [ CTor ]
    public ServiceState()
    {
        paginationCount = [];
        services = new List<OutputServiceDTO>();
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

    public List<OutputServiceDTO> Services
    {
        get { return this.services!; }
        set { this.SetProperty(ref this.services, value); }
    }

    public List<ServiceWithDeviceModel> ModifiedServices
    {
        get { return this.modifiedServices!; }
        set { this.SetProperty(ref this.modifiedServices, value); }
    }
    #endregion
}
