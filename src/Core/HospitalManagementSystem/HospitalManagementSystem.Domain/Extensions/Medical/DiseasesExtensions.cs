namespace HospitalManagementSystem.Domain;

public static class DiseasesExtensions
{
    #region [ Private Methods ]
    //private static Diseases AddDiagnosis(this Diseases disease, Diagnosis diagnosis)
    //{
    //    if (disease.Diagnoses.Any(d => d.Id == diagnosis.Id))
    //    {
    //        return disease;
    //    }

    //    diagnosis.DiseasesId = disease.Id;
    //    diagnosis.Diseases = disease;
    //    disease.Diagnoses.Add(diagnosis);
    //    return disease;
    //}

    private static Diseases AddICDCode(this Diseases disease, ICDCode icdCode)
    {
        if (disease.ICDCodes.Any(icd => icd.Code == icdCode.Code))
        {
            return disease;
        }

        icdCode.DiseasesId = disease.Id;
        icdCode.Diseases = disease;
        disease.ICDCodes.Add(icdCode);
        return disease;
    }

    private static Diseases AddICDCodeWithVersion(this Diseases disease, ICDVersion icdVersion, ICDCode icdCode, ICDCodeVersion icdCodeVersion)
    {
        if (disease.ICDCodes.Any(iv => iv.Id == icdCode.Id))
        {
            return disease;
        }

        icdCodeVersion.ICDVersionId = icdVersion.Id;
        icdCodeVersion.ICDVersion = icdVersion;
        icdCodeVersion.ICDCodeId = icdCode.Id;
        icdCodeVersion.ICDCode = icdCode;
        icdVersion.ICDCodeVersions.Add(icdCodeVersion);
        icdCode.ICDCodeVersions.Add(icdCodeVersion);
        icdCode.DiseasesId = disease.Id;
        icdCode.Diseases = disease;
        disease.ICDCodes.Add(icdCode);
        return disease;
    }
    #endregion

    #region [ Public Methods ]
    public static Diseases AddICDCode(this Diseases disease)
    {
        return disease.AddICDCode(ICDCodeFactory.Create());
    }

    public static Diseases AddICDCodeWithVersion(this Diseases disease, ICDVersion icdVersion, string code, string condition)
    {
        return disease.AddICDCodeWithVersion(icdVersion, ICDCodeFactory.Create(code, condition), ICDCodeVersionFactory.Create());
    }

    public static Diseases RemoveRelated(this Diseases diseases)
    {
        //diseases.Diagnoses.Clear();
        diseases.ICDCodes.Clear();
        return diseases;
    }
    #endregion
}
