namespace HospitalManagementSystem.Application;

public record OutputTreatmentDTO : TreatmentDTO
{
    public ICollection<OutputDiagnosisTreatmentDTO>? DiagnosisTreatments { get; init; }
}
