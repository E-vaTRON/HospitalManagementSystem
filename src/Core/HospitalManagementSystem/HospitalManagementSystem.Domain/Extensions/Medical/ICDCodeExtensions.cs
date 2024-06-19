namespace HospitalManagementSystem.Domain;

public static class ICDCodeExtensions
{
    #region [ Private Methods ]
    private static ICDCode AddICDCodeVersion(this ICDCode icdCode, ICDCodeVersion icdCodeVersion)
    {
        if (icdCode.ICDCodeVersions.Any(iv => iv.Id == icdCodeVersion.Id))
        {
            return icdCode;
        }

        icdCodeVersion.ICDCodeId = icdCode.Id;
        icdCodeVersion.ICDCode = icdCode;
        icdCode.ICDCodeVersions.Add(icdCodeVersion);
        return icdCode;
    }

    private static ICDCode AddICDCodeVersion(this ICDCode icdCode, ICDCodeVersion icdCodeVersion, ICDVersion icdVersion)
    {
        if (icdCode.ICDCodeVersions.Any(iv => iv.Id == icdCodeVersion.Id))
        {
            return icdCode;
        }

        icdCodeVersion.ICDVersionId = icdVersion.Id;
        icdCodeVersion.ICDVersion = icdVersion;
        icdCodeVersion.ICDCodeId = icdCode.Id;
        icdCodeVersion.ICDCode = icdCode;
        icdCode.ICDCodeVersions.Add(icdCodeVersion);
        icdVersion.ICDCodeVersions.Add(icdCodeVersion);
        return icdCode;
    }
    #endregion

    #region [ Public Methods ]
    public static ICDCode AddICDCodeVersion(this ICDCode icdCode)
    {
        return icdCode.AddICDCodeVersion(ICDCodeVersionFactory.Create());
    }

    public static ICDCode AddICDCodeVersion(this ICDCode icdCode, string icdCodeId, string icdVersionId)
    {
        return icdCode.AddICDCodeVersion(ICDCodeVersionFactory.Create(icdCodeId, icdVersionId));
    }

    public static ICDCode AddICDCodeVersion(this ICDCode icdCode, ICDVersion icdVersion, string icdCodeId, string icdVersionId)
    {
        return icdCode.AddICDCodeVersion(ICDCodeVersionFactory.Create(icdCodeId, icdVersionId), icdVersion);
    }
    #endregion
}
