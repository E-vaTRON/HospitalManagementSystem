namespace HospitalManagementSystem.Domain;

public static class MedicalExamEpisodeFactory
{
    public static MedicalExamEpisode Create()
    {
        return new MedicalExamEpisode();
    }

    public static MedicalExamEpisode Create(DateTime dateTakeExam, int lineNumber, DateTime recordDay, int totalPrice)
    {
        return new MedicalExamEpisode()
        {
            DateTakeExam = dateTakeExam,
            LineNumber = lineNumber,
            RecordDay = recordDay,
            TotalPrice = totalPrice
        };
    }
}