namespace HospitalManagementSystem.DataProvider;

public class MedicalService : ModelBase
{
    public string       Name                    { get; set; } = string.Empty;
    public ServiceType  Type                    { get; set; }
    public int          UnitPrice               { get; set; }                       //đơn giá
    public int          ServicePrice            { get; set; }                       //giá thu phí
    public int          HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế

    public virtual ICollection<ServiceEpisode> ServiceEpisodes { get; set; } = new HashSet<ServiceEpisode>();
}
