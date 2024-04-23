namespace HospitalManagementSystem.Domain;

public static class DiagnosisFactory
{
    public static Diagnosis Create()
    {
        return new Diagnosis();
    }

    public static Diagnosis Create(string diagnosisCode, string description, string icdId)
    {
        return new Diagnosis()
        {
            DiagnosisCode = diagnosisCode,
            Description = description,
            ICDId = icdId
        };
    }

    public static Diagnosis Create(string diagnosisCode, string icdId)
    {
        return new Diagnosis()
        {
            DiagnosisCode = diagnosisCode,
            Description = string.Empty,
            ICDId = icdId
        };
    }
}