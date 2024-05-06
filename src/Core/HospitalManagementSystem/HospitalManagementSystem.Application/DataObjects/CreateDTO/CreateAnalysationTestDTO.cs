namespace HospitalManagementSystem.Application;

public class CreateAnalyzationTestDTO : BaseDTO
{

    public string   ExamID          { get; set; } = string.Empty;

    public string   DSymptom        { get; set; } = string.Empty;       //triệu chứng lâm sàng

    public string   DoctorComment   { get; set; } = string.Empty;       //chỉ định
}
