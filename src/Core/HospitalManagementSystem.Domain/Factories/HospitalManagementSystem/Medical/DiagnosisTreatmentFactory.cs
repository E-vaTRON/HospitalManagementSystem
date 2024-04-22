namespace HospitalManagementSystem.Domain;

public static class DiagnosisTreatmentFactory
{
    public static DiagnosisTreatment Create()
    {
        return new DiagnosisTreatment();
    }

    public static DiagnosisTreatment Create(string treatmentId, string diagnosisId)
    {
        return new DiagnosisTreatment()
        {
            TreatmentId = treatmentId,
            DiagnosisId = diagnosisId
        };
    }
}
