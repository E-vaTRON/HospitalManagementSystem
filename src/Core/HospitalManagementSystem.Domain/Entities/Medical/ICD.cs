﻿namespace HospitalManagementSystem.Domain;

public class ICD : EntityBase
{
    public string       Code        { get; set; } = string.Empty;
    public string?      Description { get; set; }
    public CodeStatus   Status      { get; set; }

    public virtual ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
}