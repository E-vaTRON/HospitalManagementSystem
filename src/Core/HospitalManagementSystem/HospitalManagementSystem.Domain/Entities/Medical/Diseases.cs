﻿namespace HospitalManagementSystem.Domain;

public class Diseases : EntityBase
{
    public string       Name        { get; set; } = string.Empty;
    public string?      Description { get; set; }
    public CodeStatus   Status      { get; set; }

    public virtual ICollection<ICDCode>   ICDCodes  { get; set; } = new HashSet<ICDCode>();
}