namespace HospitalManagementSystem.Application;

public record InputICDCodeDTO : ICDCodeDTO
{
    public string? DiseasesDTOId { get; init; }
}
