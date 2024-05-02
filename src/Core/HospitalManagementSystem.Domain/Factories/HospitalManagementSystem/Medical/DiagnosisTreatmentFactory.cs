namespace HospitalManagementSystem.Domain;

public static class DiagnosisTreatmentFactory
{
    public static DiagnosisTreatment Create()
    {
        return new DiagnosisTreatment();
    }

    public static DiagnosisTreatment Create(string note, string order, string diagnosisId, string treatmentId)
    {
        return new DiagnosisTreatment()
        {
            Note = note,
            Order = order,
            DiagnosisId = diagnosisId,
            TreatmentId = treatmentId
        };
    }

    public static DiagnosisTreatment Create(string diagnosisId, string treatmentId)
    {
        return new DiagnosisTreatment()
        {
            DiagnosisId = diagnosisId,
            TreatmentId = treatmentId
        };
    }
}
