namespace HospitalManagementSystem.Domain;

public static class MeasurementUnitFactory
{
    public static MeasurementUnit Create()
    {
        return new MeasurementUnit();
    }

    public static MeasurementUnit Create(string name, string symbol)
    {
        return new MeasurementUnit
        {
            Name = name,
            Symbol = symbol
        };
    }
}
