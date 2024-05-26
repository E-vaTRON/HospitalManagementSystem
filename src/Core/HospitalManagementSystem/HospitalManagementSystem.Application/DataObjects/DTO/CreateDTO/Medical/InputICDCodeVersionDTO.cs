namespace HospitalManagementSystem.Application;

public record InputICDCodeVersionDTO : ICDCodeVersionDTO
{
    public string? ICDCodeDTOId     { get; init; }
    public string? ICDVersionDTOId  { get; init; }
}