namespace HospitalManagementSystem.Domain;

public static class TreatmentExtensions
{
    #region [ Private Methods ]
    private static Treatment AddDiagnosisTreatment(this Treatment treatment, DiagnosisTreatment diagnosisTreatment)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(diagnosisTreatment));

        if (treatment.DiagnosisTreatments.Any(x => x.Id == diagnosisTreatment.Id))
        {
            return treatment;
        }

        diagnosisTreatment.TreatmentId = treatment.Id;
        diagnosisTreatment.Treatment = treatment;
        treatment.DiagnosisTreatments.Add(diagnosisTreatment);
        return treatment;
    }
    #endregion

    #region [ Public Methods ]
    public static Treatment AddDiagnosisTreatment(this Treatment treatment)
    {
        return AddDiagnosisTreatment(treatment, DiagnosisTreatmentFactory.Create());
    }

    public static Treatment AddDiagnosisTreatment(this Treatment treatment, string note, string order, string diagnosisId, string treatmentId)
    {
        return AddDiagnosisTreatment(treatment, DiagnosisTreatmentFactory.Create(note, order, diagnosisId, treatmentId));
    }

    public static Treatment AddDiagnosisTreatment(this Treatment treatment, string diagnosisId, string treatmentId)
    {
        return AddDiagnosisTreatment(treatment, DiagnosisTreatmentFactory.Create(diagnosisId, treatmentId));
    }
    #endregion
}
