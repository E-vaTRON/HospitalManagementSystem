namespace HospitalManagementSystem.Domain;

public static class MedicalExamEpisodeFactory
{
    public static MedicalExamEpisode Create()
    {
        return new MedicalExamEpisode();
    }

    public static MedicalExamEpisode Create(DateTime dateTakeExam, DateTime dateReExam, int lineNumber, DateTime recordDay, int totalPrice, string medicalExamId)
    {
        return new MedicalExamEpisode()
        {
            DateTakeExam = dateTakeExam,
            DateReExam = dateReExam,
            LineNumber = lineNumber,
            RecordDay = recordDay,
            TotalPrice = totalPrice,
            MedicalExamId = medicalExamId
        };
    }

    public static MedicalExamEpisode Create(DateTime dateReExam, int lineNumber, DateTime recordDay, int totalPrice, string medicalExamId)
    {
        return new MedicalExamEpisode()
        {
            DateTakeExam = DateTime.Now,
            DateReExam = dateReExam,
            LineNumber = lineNumber,
            RecordDay = recordDay,
            TotalPrice = totalPrice,
            MedicalExamId = medicalExamId
        };
    }
}