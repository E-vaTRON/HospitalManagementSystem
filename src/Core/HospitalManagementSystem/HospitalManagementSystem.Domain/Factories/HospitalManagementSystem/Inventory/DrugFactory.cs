namespace HospitalManagementSystem.Domain;

public static class DrugFactory
{
    public static Drug Create()
    {
        return new Drug();
    }

    public static Drug Create(string goodName, string activeIngredientName, string interactions, string sideEffects, Units unit, string goodType, int unitPrice, int healthInsurancePrice, string country, string groupId)
    {
        return new Drug()
        {
            GoodName = goodName,
            ActiveIngredientName = activeIngredientName,
            Interactions = interactions,
            SideEffects = sideEffects,
            Unit = unit,
            GoodType = goodType,
            UnitPrice = unitPrice,
            HealthInsurancePrice = healthInsurancePrice,
            Country = country,
            GroupId = groupId
        };
    }

    public static Drug Create(string goodName, string activeIngredientName, Units unit, string goodType, string groupId)
    {
        return new Drug()
        {
            GoodName = goodName,
            ActiveIngredientName = activeIngredientName,
            Unit = unit,
            GoodType = goodType,
            UnitPrice = default!,
            HealthInsurancePrice = default!,
            GroupId = groupId
        };
    }
}
