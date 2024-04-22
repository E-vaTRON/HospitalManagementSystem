namespace HospitalManagementSystem.Domain;

public static class StorageFactory
{
    public static Storage Create()
    {
        return new Storage();
    }

    public static Storage Create(string location)
    {
        return new Storage()
        {
            Location = location
        };
    }

}
