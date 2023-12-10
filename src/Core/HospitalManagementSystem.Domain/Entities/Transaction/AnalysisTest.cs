namespace HospitalManagementSystem.Domain;

public class AnalysisTest : EntityBase
{
    public string?  DSymptom            { get; set; }        // Làm bản riêng
    public string?  DoctorComment       { get; set; }
    public string?  Result              { get; set; }

    public string?          DeviceServiceID { get; set; }
    public DeviceService    DeviceService   { get; set; } = default!;
    public string?          BillID          { get; set; }
    public Bill             Bill            { get; set; } = default!;
}