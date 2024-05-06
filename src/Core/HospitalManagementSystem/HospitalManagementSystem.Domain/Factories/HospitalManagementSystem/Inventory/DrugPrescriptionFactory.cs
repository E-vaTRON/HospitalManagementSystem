namespace HospitalManagementSystem.Domain;

public static class DrugPrescriptionFactory
{
    public static DrugPrescription Create()
    {
        return new DrugPrescription();
    }

    public static DrugPrescription Create(string medicalExamEpisodeId, string drugInventoryId)
    {
        return new DrugPrescription()
        {
            MedicalExamEpisodeId = medicalExamEpisodeId,
            DrugInventoryId = drugInventoryId
        };
    }
}