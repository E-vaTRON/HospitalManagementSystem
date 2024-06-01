namespace HospitalManagementSystem.Application;

public record OutputICDCodeVersionDTO : ICDCodeVersionDTO
{
    public OutputICDCodeDTO?      ICDCodeDTO      { get; init; }
    public OutputICDVersionDTO?   ICDVersionDTO   { get; init; }
}
