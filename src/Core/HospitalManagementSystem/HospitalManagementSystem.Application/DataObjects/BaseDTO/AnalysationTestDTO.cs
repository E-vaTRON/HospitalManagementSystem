namespace HospitalManagementSystem.Application;

//[ModelBinder(typeof(MultipleSourcesModelBinder<
//
//TestDTO>))]
public class AnalyzationTestDTO : BaseDTO
{
    public string   DeviceID        { get; set; } = string.Empty;
    public string   ExamID          { get; set; } = string.Empty;
    public string   DSymptom        { get; set; } = string.Empty;       //triệu chứng lâm sàng
    public string   DoctorComment   { get; set; } = string.Empty;       // chỉ định
}
