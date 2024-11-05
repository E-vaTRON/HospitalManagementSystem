namespace HospitalManagementSystem.Domain;

public static class DiagnosisTreatmentExtensions
{
    public static DiagnosisTreatment RemoveRelated(this DiagnosisTreatment diagnosisTreatment)
    {
        diagnosisTreatment.Treatment = null!;
        diagnosisTreatment.Diagnosis = null!;
        return diagnosisTreatment;
    }
}
