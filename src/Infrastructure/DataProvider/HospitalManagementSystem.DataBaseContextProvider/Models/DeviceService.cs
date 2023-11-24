namespace HospitalManagementSystem.DataBaseContextProvider;

public class DeviceService : BaseModel<Guid>
{
    public string       DeviceName              { get; set; } = string.Empty;       //tên thiết bị
    public string       Service                 { get; set; } = string.Empty;       //tên dich vụ
    public Units        Unit                    { get; set; }                       //đơn vị tính
    public int          UnitPrice               { get; set; }                       //đơn giá
    public int          ServicePrice            { get; set; }                       //giá thu phí
    public int          HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
    public string       ManagementID            { get; set; } = string.Empty;       //mã quản lí
    public string       Country                 { get; set; } = string.Empty;       //nước sản xuất 
    public string       SmallID                 { get; set; } = string.Empty;       //mã con
    public string       GroupID                 { get; set; } = string.Empty;       //mã số nhóm
    public int          Min                     { get; set; }                       //MIN
    public int          Max                     { get; set; }                       //MAX
    public FormTypes    ResultFromType          { get; set; }                       //form kết quả chuẩn đoán

    public virtual ICollection<AnalyzationTest>     AnalyzationTests    { get; set; } = new HashSet<AnalyzationTest>();
}
