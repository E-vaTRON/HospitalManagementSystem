namespace HospitalManagementSystem.Application;

public record DrugPrescriptionDTO : DTOBase
{
    public int Amount { get; set; }
}