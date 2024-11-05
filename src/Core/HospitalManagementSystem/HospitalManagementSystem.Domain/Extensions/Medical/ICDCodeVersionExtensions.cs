namespace HospitalManagementSystem.Domain;

public static class ICDCodeVersionExtensions
{
    public static ICDCodeVersion RemoveRelated(this ICDCodeVersion icdCodeVersion)
    {
        icdCodeVersion.ICDVersion = null!;
        icdCodeVersion.ICDCode = null!;
        return icdCodeVersion;
    }
}
