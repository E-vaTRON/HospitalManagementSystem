namespace HospitalManagementSystem.Application;

public class PatientDTO
{
    public string   PatientID       { get; set; } = string.Empty;
    public string   FirstName       { get; set; } = string.Empty;       //họ
    public string   LastName        { get; set; } = string.Empty;       //tên
    public string   DayOfBirth      { get; set; } = string.Empty;       //ngày sinh
    public int      Age             { get; set; }                       //tuổi
    public bool     Gender          { get; set; }                       //giới tính
    public string   Address         { get; set; } = string.Empty;       //địa chỉ
    public string   CardID          { get; set; } = string.Empty;       //mã thẻ
    public string   PnoneNumber     { get; set; } = string.Empty;       //số điện thoại
}