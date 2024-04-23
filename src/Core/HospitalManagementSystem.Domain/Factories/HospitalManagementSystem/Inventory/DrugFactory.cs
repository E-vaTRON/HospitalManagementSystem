namespace HospitalManagementSystem.Domain;

public static class DrugFactory
{
    public static Drug Create()
    {
        return new Drug();
    }

    public static Drug Create(string goodName, string activeIngredientName, Units unit, string goodType, int unitPrice, int healthInsurancePrice, string country, string groupId)
    {
        return new Drug()
        {
            GoodName = goodName,
            ActiveIngredientName = activeIngredientName,
            Unit = unit,
            GoodType = goodType,
            UnitPrice = unitPrice,
            HealthInsurancePrice = healthInsurancePrice,
            Country = country,
            GroupId = groupId
        };
    }

    public static Drug Create(string goodName, string activeIngredientName, Units unit, string goodType, string country, string groupId)
    {
        return new Drug()
        {
            GoodName = goodName,
            ActiveIngredientName = activeIngredientName,
            Unit = unit,
            GoodType = goodType,
            UnitPrice = default!,
            HealthInsurancePrice = default!,
            Country = country,
            GroupId = groupId
        };
    }
}
