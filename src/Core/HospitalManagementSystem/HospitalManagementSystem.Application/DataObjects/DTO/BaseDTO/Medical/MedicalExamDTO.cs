namespace HospitalManagementSystem.Application;

public record MedicalExamDTO : DTOBase
{
    public int? FinalPrice { get; init; }
}