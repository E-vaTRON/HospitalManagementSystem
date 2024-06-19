namespace HospitalManagementSystem.Domain;

public static class DiagnosisExtensions
{
    #region [ Private Methods ]
    private static Diagnosis AddDiagnosisTreatment(this Diagnosis diagnosis, DiagnosisTreatment diagnosisTreatment)
    {
        if (diagnosis.DiagnosisTreatments.Any(dt => dt.Id == diagnosisTreatment.Id))
        {
            return diagnosis;
        }

        diagnosisTreatment.DiagnosisId = diagnosis.Id.ToString();
        diagnosisTreatment.Diagnosis = diagnosis;
        diagnosis.DiagnosisTreatments.Add(diagnosisTreatment);
        return diagnosis;
    }
    #endregion

    #region [ Public Methods ]
    public static Diagnosis AddDiagnosisTreatment(this Diagnosis diagnosis)
    {
        return diagnosis.AddDiagnosisTreatment(DiagnosisTreatmentFactory.Create());
    }

    public static Diagnosis AddDiagnosisTreatment(this Diagnosis diagnosis, string note, string order, string treatmentId)
    {
        return diagnosis.AddDiagnosisTreatment(DiagnosisTreatmentFactory.Create(note, order, diagnosis.Id.ToString(), treatmentId));
    }

    public static Diagnosis AddDiagnosisTreatment(this Diagnosis diagnosis, string treatmentId)
    {
        return diagnosis.AddDiagnosisTreatment(DiagnosisTreatmentFactory.Create(diagnosis.Id.ToString(), treatmentId));
    }
    #endregion
}
