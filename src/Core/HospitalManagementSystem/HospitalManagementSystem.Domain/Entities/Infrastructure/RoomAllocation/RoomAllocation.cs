namespace HospitalManagementSystem.Domain;

public class RoomAllocation : EntityBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?  PatientId   { get; set; } // User Id Role<Patient>
    public string?  EmployeeId  { get; set; } // User Id Role<Employee>

    public string?              RoomId                  { get; set; }
    public Room                 Room                    { get; set; } = default!;
    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;
}