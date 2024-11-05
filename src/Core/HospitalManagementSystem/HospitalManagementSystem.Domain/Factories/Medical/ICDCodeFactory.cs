namespace HospitalManagementSystem.Domain;

public class ICDCodeFactory
{
    public static ICDCode Create()
    {
        return new ICDCode();
    }

    public static ICDCode Create(string code, string condition)
    {
        return new ICDCode()
        {
            Code = code,
            Condition = condition
        };
    }
}
