namespace HospitalManagementSystem.Application;

public record ICDCodeDTO : DTOBase
{
    public string?      Code         { get; init; }
}
