namespace HospitalManagementSystem.Domain;

public static class DrugPrescriptionExtensions
{
    public static DrugPrescription RemoveRelated(this DrugPrescription drugPrescription)
    {
        drugPrescription.MedicalExamEpisode = null!;
        drugPrescription.DrugInventory = null!;
        return drugPrescription;
    }
}
