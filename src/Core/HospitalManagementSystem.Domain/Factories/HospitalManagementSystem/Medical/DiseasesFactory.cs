namespace HospitalManagementSystem.Domain;

public static class DiseasesFactory
{
    public static Diseases Create()
    {
        return new Diseases();
    }

    public static Diseases Create(string name, string description, CodeStatus status)
    {
        return new Diseases()
        {
            Name = name,
            Description = description,
            Status = status
        };
    }

}