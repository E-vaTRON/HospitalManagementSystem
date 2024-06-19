namespace HospitalManagementSystem.Domain;

public static class DiseasesExtensions
{
    #region [ Private Methods ]
    private static Diseases AddDiagnosis(this Diseases disease, Diagnosis diagnosis)
    {
        if (disease.Diagnoses.Any(d => d.Id == diagnosis.Id))
        {
            return disease;
        }

        diagnosis.DiseasesId = disease.Id;
        diagnosis.Diseases = disease;
        disease.Diagnoses.Add(diagnosis);
        return disease;
    }

    private static Diseases AddICDCode(this Diseases disease, ICDCode icdCode)
    {
        if (disease.ICDCodes.Any(icd => icd.Id == icdCode.Id))
        {
            return disease;
        }

        icdCode.DiseasesId = disease.Id;
        icdCode.Diseases = disease;
        disease.ICDCodes.Add(icdCode);
        return disease;
    }
    #endregion

    #region [ Public Methods ]
    public static Diseases AddDiagnosis(this Diseases disease)
    {
        return disease.AddDiagnosis(DiagnosisFactory.Create());
    }

    public static Diseases AddDiagnosis(this Diseases disease, string diagnosisCode, string description, string medicalExamEpisodeId)
    {
        return disease.AddDiagnosis(DiagnosisFactory.Create(diagnosisCode, description, disease.Id.ToString(), medicalExamEpisodeId));
    }

    public static Diseases AddDiagnosis(this Diseases disease, string diagnosisCode, string medicalExamEpisodeId)
    {
        return disease.AddDiagnosis(DiagnosisFactory.Create(diagnosisCode, disease.Id.ToString(), medicalExamEpisodeId));
    }

    public static Diseases AddICDCode(this Diseases disease)
    {
        return disease.AddICDCode(ICDCodeFactory.Create());
    }

    public static Diseases AddICDCode(this Diseases disease, string code)
    {
        return disease.AddICDCode(ICDCodeFactory.Create(code));
    }
    #endregion
}
