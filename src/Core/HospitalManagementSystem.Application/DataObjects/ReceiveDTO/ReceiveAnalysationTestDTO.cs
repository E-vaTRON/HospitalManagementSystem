namespace HospitalManagementSystem.Application;

public class ReceiveAnalyzationTestDTO : BaseDTO
{
    public string?  LastName        { get; set; }
    public string?  Service         { get; set; }
    public string   DSymptom        { get; set; } = string.Empty;           //triệu chứng lâm sàng
    public string   DoctorComment   { get; set; } = string.Empty;      // chỉ định
}
