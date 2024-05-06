namespace HospitalManagementSystem.DataProvider;

public class RoomAllocation : ModelBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?  PatientId   { get; set; } // User Id Role<Patient>

    public Guid?                RoomId                  { get; set; }
    public Room                 Room                    { get; set; } = default!;
    public Guid?                MedicalExamEposodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEposode      { get; set; } = default!;
}