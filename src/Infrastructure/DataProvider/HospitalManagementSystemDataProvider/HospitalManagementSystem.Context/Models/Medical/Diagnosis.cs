﻿namespace HospitalManagementSystem.DataProvider;

public class Diagnosis : ModelBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Description     { get; set; }

    public string?              ExamEposodeId       { get; set; }
    public MedicalExamEposode   MedicalExamEposode  { get; set; } = default!;
    public string?              ICDDId              { get; set; }
    public ICDD                 ICDD                { get; set; } = default!;

    public virtual ICollection<Employee>            Employees               { get; set; } = new HashSet<Employee>();
    public virtual ICollection<DiagnosisSuggestion> DiagnosisSuggestions    { get; set; } = new HashSet<DiagnosisSuggestion>();
}