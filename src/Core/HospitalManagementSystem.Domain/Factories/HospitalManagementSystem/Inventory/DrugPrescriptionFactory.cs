namespace HospitalManagementSystem.Domain;

public static class DrugPrescriptionFactory
{
    public static DrugPrescription Create()
    {
        return new DrugPrescription();
    }

    public static DrugPrescription Create(string medicalExamEposodeId, string drugInventoryId)
    {
        return new DrugPrescription()
        {
            MedicalExamEposodeId = medicalExamEposodeId,
            DrugInventoryId = drugInventoryId
        };
    }
}