namespace HospitalManagementSystem.Application;

public class RoomAllocationDTO : DTOBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?  PatientId   { get; set; } // User Id Role<Patient>


    public RoomDTO                  RoomDTO                    { get; set; } = default!;
    public MedicalExamEpisodeDTO    MedicalExamEpisodeDTO      { get; set; } = default!;
}