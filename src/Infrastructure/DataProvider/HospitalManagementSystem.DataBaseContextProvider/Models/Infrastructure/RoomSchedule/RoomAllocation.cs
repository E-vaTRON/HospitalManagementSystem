namespace HospitalManagementSystem.DataBaseContextProvider;

public class RoomAllocation : ModelBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?              RoomId                  { get; set; }
    public Room                 Room                    { get; set; } = default!;
    public string?              PatientId               { get; set; }
    public Patient              Patient                 { get; set; } = default!;
    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}