namespace HospitalManagementSystem.Domain;

public static class MedicalServiceFactory
{
    public static MedicalService Create()
    {
        return new MedicalService();
    }

    public static MedicalService Create(string name, ServiceType type, int unitPrice, int servicePrice, int healthInsurancePrice)
    {
        return new MedicalService()
        {
            Name = name,
            Type = type,
            UnitPrice = unitPrice,
            ServicePrice = servicePrice,
            HealthInsurancePrice = healthInsurancePrice,
        };
    }

    public static MedicalService Create(string name, ServiceType type)
    {
        return new MedicalService()
        {
            Name = name,
            Type = type,
            UnitPrice = default!,
            ServicePrice = default!,
            HealthInsurancePrice = default!,
        };
    }
}
