namespace HospitalManagementSystem.Domain;

public static class ICDVersionExtensions
{
    #region [ Private Methods ]
    private static ICDVersion AddICDCodeVersion(this ICDVersion icdVersion, ICDCodeVersion icdCodeVersion)
    {
        if (icdVersion.ICDCodeVersions.Any(iv => iv.Id == icdCodeVersion.Id))
        {
            return icdVersion;
        }

        icdCodeVersion.ICDVersionId = icdVersion.Id;
        icdCodeVersion.ICDVersion = icdVersion;
        icdVersion.ICDCodeVersions.Add(icdCodeVersion);
        return icdVersion;
    }

    private static ICDVersion AddICDCodeVersion(this ICDVersion icdVersion, ICDCodeVersion icdCodeVersion, ICDCode icdCode)
    {
        if (icdVersion.ICDCodeVersions.Any(iv => iv.Id == icdCodeVersion.Id))
        {
            return icdVersion;
        }

        icdCodeVersion.ICDVersionId = icdVersion.Id;
        icdCodeVersion.ICDVersion = icdVersion;
        icdCodeVersion.ICDCodeId = icdCode.Id;
        icdCodeVersion.ICDCode = icdCode;
        icdCode.ICDCodeVersions.Add(icdCodeVersion);
        icdVersion.ICDCodeVersions.Add(icdCodeVersion);
        return icdVersion;
    }
    #endregion

    #region [ Public Methods ]
    public static ICDVersion AddICDCodeVersion(this ICDVersion icdVersion)
    {
        return icdVersion.AddICDCodeVersion(ICDCodeVersionFactory.Create());
    }

    public static ICDVersion AddICDCodeVersion(this ICDVersion icdVersion, string icdCodeId, string icdVersionId)
    {
        return icdVersion.AddICDCodeVersion(ICDCodeVersionFactory.Create(icdCodeId, icdVersionId));
    }

    public static ICDVersion AddICDCodeVersion(this ICDVersion icdVersion, ICDCode icdCode, string icdCodeId, string icdVersionId)
    {
        return icdVersion.AddICDCodeVersion(ICDCodeVersionFactory.Create(icdCodeId, icdVersionId), icdCode);
    }
    #endregion
}
