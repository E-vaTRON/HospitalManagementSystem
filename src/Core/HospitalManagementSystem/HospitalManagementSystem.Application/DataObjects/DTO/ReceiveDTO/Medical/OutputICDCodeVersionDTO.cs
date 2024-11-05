namespace HospitalManagementSystem.Application;

public record OutputICDCodeVersionDTO : ICDCodeVersionDTO
{
    public OutputICDCodeDTO?      ICDCode      { get; init; }
    public OutputICDVersionDTO?   ICDVersion   { get; init; }
}
