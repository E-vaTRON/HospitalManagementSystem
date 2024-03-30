namespace HospitalManagementSystem.DataProvider;

public class AssignmentHistory : ModelBase
{
    public string? AssignmentStatus { get; set; }

    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public string?              DoctorId                { get; set; }
    public Doctor               Doctor                  { get; set; } = default!;


    public string?          ReferralDoctorId    { get; set; }
    public ReferralDoctor   ReferralDoctor      { get; set; } = null!;
}
