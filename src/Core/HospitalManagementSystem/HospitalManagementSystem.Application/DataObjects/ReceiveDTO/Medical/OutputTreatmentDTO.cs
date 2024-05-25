namespace HospitalManagementSystem.Application;

public record OutputTreatmentDTO : TreatmentDTO
{
    public ICollection<DiagnosisTreatmentDTO>? DiagnosisTreatmentDTOs { get; set; }
}
