namespace HospitalManagementSystem.Domain;

public static class ServiceFactory
{
    public static Service Create()
    {
        return new Service();
    }

    public static Service Create(string name, Units unit, int unitPrice, int servicePrice, int healthInsurancePrice, FormTypes resultFromType)
    {
        return new Service()
        {
            Name = name,
            Unit = unit,
            UnitPrice = unitPrice,
            ServicePrice = servicePrice,
            HealthInsurancePrice = healthInsurancePrice,
            ResultFromType = resultFromType
        };
    }

    public static Service Create(string name, Units unit, FormTypes resultFromType)
    {
        return new Service()
        {
            Name = name,
            Unit = unit,
            UnitPrice = default!,
            ServicePrice = default!,
            HealthInsurancePrice = default!,
            ResultFromType = resultFromType
        };
    }
}
