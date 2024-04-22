namespace HospitalManagementSystem.Domain;

public static class MedicalDeviceFactory
{
    public static MedicalDevice Create()
    {
        return new MedicalDevice();
    }

    public static MedicalDevice Create(string name, string country, string smallID, string groupID, int min, int max)
    {
        return new MedicalDevice()
        {
            Name = name,
            Country = country,
            SmallID = smallID,
            GroupID = groupID,
            Min = min,
            Max = max
        };
    }
}
