namespace HospitalManagementSystem.Domain;

public static class ICDCodeVersionFactory
{
    public static ICDCodeVersion Create()
    {
        return new ICDCodeVersion();
    }

    public static ICDCodeVersion Create(string icdCodeId, string icdVersionId)
    {
        return new ICDCodeVersion()
        {
            ICDCodeId = icdCodeId,
            ICDVersionId = icdCodeId
        };
    }
}
