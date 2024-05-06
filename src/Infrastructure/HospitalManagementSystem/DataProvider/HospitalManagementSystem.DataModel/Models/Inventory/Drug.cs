namespace HospitalManagementSystem.DataProvider;

public class Drug : ModelBase
{
    public string       GoodName                { get; set; } = string.Empty;       //tên hàng
    public string       ActiveIngredientName    { get; set; } = string.Empty;       //tên hoạt chất
    public string       Interactions            { get; set; } = string.Empty;
    public string       SideEffects             { get; set; } = string.Empty;
    public Units        Unit                    { get; set; }                       //đơn vị tính
    public string       GoodType                { get; set; } = string.Empty;       //loại hàng hóa
    public int          UnitPrice               { get; set; }                       //đơn giá
    public int          HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
    public string       Country                 { get; set; } = string.Empty;       //nước sản xuất
    public string       GroupId                 { get; set; } = string.Empty;       //mã số nhóm

    public virtual ICollection<GoodSuppling> GoodSupplings { get; set; } = new HashSet<GoodSuppling>();
}
