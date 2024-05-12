namespace HospitalManagementSystem.Application;

public class ICDCodeVersionDTO : DTOBase
{
    public virtual ICDCodeDTO      ICDCodeDTO       { get; set; } = default!;
    public virtual ICDVersionDTO   ICDVersionDTO    { get; set; } = default!;
}
