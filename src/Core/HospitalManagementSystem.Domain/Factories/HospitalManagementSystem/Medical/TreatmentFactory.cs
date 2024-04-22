namespace HospitalManagementSystem.Domain;

public static class TreatmentFactory
{
    public static Treatment Create()
    {
        return new Treatment();
    }

    public static Treatment Create(string name, string description)
    {
        return new Treatment()
        {
            Name = name,
            Description = description
        };
    }

    public static Treatment Create(string name)
    {
        return new Treatment()
        {
            Name = name,
            Description = string.Empty
        };
    }
}
