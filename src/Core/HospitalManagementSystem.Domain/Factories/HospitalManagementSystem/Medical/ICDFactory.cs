namespace HospitalManagementSystem.Domain;

public static class ICDFactory
{
    public static Diseases Create()
    {
        return new Diseases();
    }

    public static Diseases Create(string code, string description, CodeStatus status)
    {
        return new Diseases()
        {
            Code = code,
            Description = description,
            Status = status
        };
    }

}