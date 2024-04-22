namespace HospitalManagementSystem.Domain;

public static class TreatmentExamEpisodeFactory
{
    public static TreatmentExamEpisode Create()
    {
        return new TreatmentExamEpisode();
    }

    public static TreatmentExamEpisode Create(string treatmentId, string medicalExamEpisode)
    {
        return new TreatmentExamEpisode()
        {
            TreatmentId = treatmentId,
            MedicalExamEpisode = medicalExamEpisode
        };
    }
}
