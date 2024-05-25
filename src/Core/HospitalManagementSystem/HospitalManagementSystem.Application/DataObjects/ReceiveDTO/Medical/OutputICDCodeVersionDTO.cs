namespace HospitalManagementSystem.Application;

public record OutputICDCodeVersionDTO : ICDCodeVersionDTO
{
    public ICDCodeDTO?      ICDCodeDTO      { get; set; }
    public ICDVersionDTO?   ICDVersionDTO   { get; set; }
}
