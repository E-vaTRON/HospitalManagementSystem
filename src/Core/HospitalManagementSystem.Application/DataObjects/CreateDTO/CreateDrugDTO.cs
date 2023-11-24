using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application;

public class CreateDrugDTO
{
    [Required]
    public string   GoodName                { get; set; } = string.Empty;       //tên hàng

    [Required]
    public string   ActiveIngredientName    { get; set; } = string.Empty;       //tên hoạt chất

    public string   Unit                    { get; set; } = string.Empty;       //đơn vị tính

    public string   GoodType                { get; set; } = string.Empty;       //loại hàng hóa

    public string   UnitPrice               { get; set; } = string.Empty;       //đơn giá

    public int      HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế

    public string   ManagementID            { get; set; } = string.Empty;       //mã quản lý

    public string   Country                 { get; set; } = string.Empty;       //nước sản xuất

    public string   GroupID                 { get; set; } = string.Empty;       //mã số nhóm
}
