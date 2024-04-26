namespace HospitalManagementSystem.Domain;

public static class TreatmentExamEpisodeFactory
{
    public static TreatmentExamEpisode Create()
    {
        return new TreatmentExamEpisode();
    }

    public static TreatmentExamEpisode Create(string treatmentId, string medicalExamEpisodeId)
    {
        return new TreatmentExamEpisode()
        {
            TreatmentId = treatmentId,
            MedicalExamEpisodeId = medicalExamEpisodeId
        };
    }
}
