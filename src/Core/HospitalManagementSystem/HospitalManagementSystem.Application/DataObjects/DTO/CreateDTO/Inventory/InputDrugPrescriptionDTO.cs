namespace HospitalManagementSystem.Application;

public record InputDrugPrescriptionDTO : DrugPrescriptionDTO
{
    public string? MedicalExamEpisodeDTOId  { get; init; }
    public string? DrugInventoryDTOId       { get; init; }
}