namespace HospitalManagementSystem.Application;

public record OutputICDCodeVersionDTO : ICDCodeVersionDTO
{
    public ICDCodeDTO?      ICDCodeDTO      { get; init; }
    public ICDVersionDTO?   ICDVersionDTO   { get; init; }
}
