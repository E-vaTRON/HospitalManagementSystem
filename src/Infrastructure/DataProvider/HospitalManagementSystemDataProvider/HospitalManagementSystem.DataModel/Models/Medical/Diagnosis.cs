﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.DataProvider;

public class Diagnosis : ModelBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Description     { get; set; }

    public string?              ICDId               { get; set; }
    public ICD                  ICD                 { get; set; } = default!;

    public virtual ICollection<DiagnosisSuggestion> DiagnosisSuggestions    { get; set; } = new HashSet<DiagnosisSuggestion>();
    public virtual ICollection<DiagnosisTreatment>  DiagnosisTreatments     { get; set; } = new HashSet<DiagnosisTreatment>();
}