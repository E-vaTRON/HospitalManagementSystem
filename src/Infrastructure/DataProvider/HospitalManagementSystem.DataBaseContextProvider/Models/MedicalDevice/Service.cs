namespace HospitalManagementSystem.DataProvider;

public class Service : ModelBase
{
    public string       Name                    { get; set; } = string.Empty;
    public Units        Unit                    { get; set; }                       //đơn vị tính //// ????
    public int          UnitPrice               { get; set; }                       //đơn giá
    public int          ServicePrice            { get; set; }                       //giá thu phí
    public int          HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
    public FormTypes    ResultFromType          { get; set; }                       //form kết quả chuẩn đoán

    public virtual ICollection<DeviceService>   DeviceServices  { get; set; } = new HashSet<DeviceService>();
}
