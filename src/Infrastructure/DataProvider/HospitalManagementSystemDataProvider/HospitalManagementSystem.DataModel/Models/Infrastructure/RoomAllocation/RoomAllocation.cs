namespace HospitalManagementSystem.DataProvider;

public class RoomAllocation : ModelBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?  PatientId   { get; set; } // User Id Role<Patient>

    public string?              RoomId                  { get; set; }
    public Room                 Room                    { get; set; } = default!;
    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}