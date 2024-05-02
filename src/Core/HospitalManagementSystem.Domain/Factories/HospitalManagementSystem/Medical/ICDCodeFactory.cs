namespace HospitalManagementSystem.Domain;

public class ICDCodeFactory
{
    public static ICDCode Create()
    {
        return new ICDCode();
    }

    public static ICDCode Create(string code)
    {
        return new ICDCode()
        {
            Code = code
        };
    }
}
