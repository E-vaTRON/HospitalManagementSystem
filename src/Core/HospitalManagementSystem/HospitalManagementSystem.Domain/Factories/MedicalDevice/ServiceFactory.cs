namespace HospitalManagementSystem.Domain;

public static class ServiceFactory
{
    public static Service Create()
    {
        return new Service();
    }

    public static Service Create(string name, ServiceType type, int unitPrice, int servicePrice, int healthInsurancePrice, FormTypes resultFromType)
    {
        return new Service()
        {
            Name = name,
            Type = type,
            UnitPrice = unitPrice,
            ServicePrice = servicePrice,
            HealthInsurancePrice = healthInsurancePrice,
            ResultFromType = resultFromType
        };
    }

    public static Service Create(string name, ServiceType type, FormTypes resultFromType)
    {
        return new Service()
        {
            Name = name,
            Type = type,
            UnitPrice = default!,
            ServicePrice = default!,
            HealthInsurancePrice = default!,
            ResultFromType = resultFromType
        };
    }
}
