using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HospitalManagementSystem.Domain;

public class Diagnosis : EntityBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Description     { get; set; }

    public string?              ExamEposodeId       { get; set; }
    public MedicalExamEposode   MedicalExamEposode  { get; set; } = default!;
    public string?              ICDDId              { get; set; }
    public ICDD                 ICDD                { get; set; } = default!;

    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}