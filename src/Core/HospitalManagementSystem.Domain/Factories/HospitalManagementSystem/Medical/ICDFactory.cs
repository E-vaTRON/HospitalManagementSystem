namespace HospitalManagementSystem.Domain;

public static class ICDFactory
{
    public static ICD Create()
    {
        return new ICD();
    }

    public static ICD Create(string code, string description, CodeStatus status)
    {
        return new ICD()
        {
            Code = code,
            Description = description,
            Status = status
        };
    }

}