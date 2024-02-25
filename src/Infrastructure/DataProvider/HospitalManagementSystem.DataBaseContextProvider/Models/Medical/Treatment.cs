namespace HospitalManagementSystem.DataProvider;

public class Treatment : ModelBase
{
    public string TreatmentCode { get; set; } = string.Empty;
    public string? Description { get; set; }


    public string?              ExamEposodeId       { get; set; }
    public MedicalExamEposode   MedicalExamEposode  { get; set; } = default!;
    public string?              ICDId               { get; set; }
    public ICD                  ICD                 { get; set; } = default!;

    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
