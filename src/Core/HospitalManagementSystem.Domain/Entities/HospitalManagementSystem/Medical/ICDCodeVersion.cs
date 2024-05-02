namespace HospitalManagementSystem.Domain;

public class ICDCodeVersion : EntityBase
{
    public Guid?                ICDCodeId       { get; set; }
    public virtual ICDCode      ICDCode         { get; set; } = default!;
    public Guid?                ICDVersionId    { get; set; }
    public virtual ICDVersion   ICDVersion      { get; set; } = default!;
}
