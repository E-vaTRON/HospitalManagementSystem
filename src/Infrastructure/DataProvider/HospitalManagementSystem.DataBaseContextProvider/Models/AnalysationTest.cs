namespace HospitalManagementSystem.DataBaseContextProvider;

public class
    AnalyzationTest : BaseModel<Guid>
{
    public string?  DeviceID        { get; set; } = string.Empty;
    public string?  ExamID          { get; set; } = string.Empty;
    public string?  DSymptom        { get; set; } = string.Empty;           
    public string?  DoctorComment   { get; set; } = string.Empty;

    public HistoryMedicalExam? HistoryMedicalExam { get; set; }
    public DeviceService?      DeviceService      { get; set; }
}
