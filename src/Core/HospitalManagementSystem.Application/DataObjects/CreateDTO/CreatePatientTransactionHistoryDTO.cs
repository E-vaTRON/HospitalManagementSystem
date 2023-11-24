using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application;

public class CreatePatientTransactionHistoryDTO
{
    [Required]
    public string   RecordDay       { get; set; } = string.Empty;       //ngày ghi sổ

    [Required]
    public string   GoodID          { get; set; } = string.Empty;       //mã hàng

    [Required]
    public int      InventoryID     { get; set; }                       //mã kho

    [Required]
    public string   ExamID          { get; set; } = string.Empty;

    [Required]
    public string   ShipmentID      { get; set; } = string.Empty;       //số lô

    [Required]
    public int      Amount          { get; set; }                       //số lượng

    [Required]
    public int      TotalPrice      { get; set; }                       //thành tiền

    [Required]
    public int      PatientID       { get; set; }                       //mã số bệnh nhân
}
