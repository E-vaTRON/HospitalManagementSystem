namespace HospitalManagementSystem.Domain;

public static class MedicalExamEposodeFactory
{
    public static MedicalExamEposode Create()
    {
        return new MedicalExamEposode();
    }

    public static MedicalExamEposode Create(DateTime dateTakeExam, DateTime dateReExam, int lineNumber, DateTime recordDay, int totalPrice, string medicalExamId, string reExamAppointmentId)
    {
        return new MedicalExamEposode()
        {
            DateTakeExam = dateTakeExam,
            DateReExam = dateReExam,
            LineNumber = lineNumber,
            RecordDay = recordDay,
            TotalPrice = totalPrice,
            MedicalExamId = medicalExamId,
            ReExamAppointmentId = reExamAppointmentId
        };
    }

    public static MedicalExamEposode Create(DateTime dateReExam, int lineNumber, DateTime recordDay, int totalPrice, string medicalExamId, string reExamAppointmentId)
    {
        return new MedicalExamEposode()
        {
            DateTakeExam = DateTime.Now,
            DateReExam = dateReExam,
            LineNumber = lineNumber,
            RecordDay = recordDay,
            TotalPrice = totalPrice,
            MedicalExamId = medicalExamId,
            ReExamAppointmentId = reExamAppointmentId
        };
    }
}