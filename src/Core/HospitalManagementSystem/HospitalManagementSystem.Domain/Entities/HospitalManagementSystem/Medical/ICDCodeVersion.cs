namespace HospitalManagementSystem.Domain;

public class ICDCodeVersion : EntityBase
{
    public string?              ICDCodeId       { get; set; }
    public virtual ICDCode      ICDCode         { get; set; } = default!;
    public string?              ICDVersionId    { get; set; }
    public virtual ICDVersion   ICDVersion      { get; set; } = default!;
}
