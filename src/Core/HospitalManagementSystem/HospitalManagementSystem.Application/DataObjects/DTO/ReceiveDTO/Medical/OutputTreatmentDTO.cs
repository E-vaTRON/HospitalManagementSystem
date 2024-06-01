namespace HospitalManagementSystem.Application;

public record OutputTreatmentDTO : TreatmentDTO
{
    public ICollection<OutputDiagnosisTreatmentDTO>? DiagnosisTreatmentDTOs { get; init; }
}
