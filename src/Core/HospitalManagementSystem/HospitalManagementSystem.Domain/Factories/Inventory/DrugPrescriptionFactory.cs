namespace HospitalManagementSystem.Domain;

public static class DrugPrescriptionFactory
{
    public static DrugPrescription Create()
    {
        return new DrugPrescription();
    }

    public static DrugPrescription Create(int amount)
    {
        return new DrugPrescription()
        {
            Amount = amount,
        };
    }
}