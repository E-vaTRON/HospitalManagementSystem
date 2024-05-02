namespace HospitalManagementSystem.Domain;

public static class ICDVersionFactory
{
    public static ICDVersion Create()
    {
        return new ICDVersion();
    }

    public static ICDVersion Create(string version)
    {
        return new ICDVersion()
        {
            Version = version,
        };
    }
}
