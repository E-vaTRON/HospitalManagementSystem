namespace HospitalManagementSystem.Application;

public record DrugDTO : DTOBase
{
    public string       GoodName                { get; init; } = string.Empty;       //tên hàng
    public string       ActiveIngredientName    { get; init; } = string.Empty;       //tên hoạt chất
    public string       Interactions            { get; init; } = string.Empty;
    public string       SideEffects             { get; init; } = string.Empty;
    public Units        Unit                    { get; init; }                       //đơn vị tính
    public string       GoodType                { get; init; } = string.Empty;       //loại hàng hóa ??????
    public int          UnitPrice               { get; init; }                       //đơn giá
    public int          HealthInsurancePrice    { get; init; }                       //giá bảo hiểm y tế
    public string       Country                 { get; init; } = string.Empty;       //nước sản xuất
    public string       GroupId                 { get; init; } = string.Empty;       //mã số nhóm
}
