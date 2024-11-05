namespace HospitalManagementSystem.Domain;

public static class DiagnosisFactory
{
    public static Diagnosis Create()
    {
        return new Diagnosis();
    }

    public static Diagnosis Create(string diagnosisCode, string description)
    {
        return new Diagnosis()
        {
            DiagnosisCode = diagnosisCode,
            Description = description
        };
    }
}