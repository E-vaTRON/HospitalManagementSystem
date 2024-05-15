namespace HospitalManagementSystem.Domain;

public static class ReExamAppointmentFactory
{
    #region [ Methods ]
    public static ReExamAppointment Create()
    {
        return new ReExamAppointment();
    }

    public static ReExamAppointment Create(string patientId, string medicalExamEpisodeId, string notes, DateTime dateTime)
    {
        return new ReExamAppointment()
        {
            AppointmentDate = dateTime,
            MedicalExamEpisodeId = medicalExamEpisodeId,
            PatientId = patientId,
            Notes = notes
        };
    }

    public static ReExamAppointment Create(string patientId, string medicalExamEpisodeId, string notes)
    {
        return new ReExamAppointment()
        {
            AppointmentDate = DateTime.Now,
            MedicalExamEpisodeId = medicalExamEpisodeId,
            PatientId = patientId,
            Notes = notes
        };
    }
    #endregion
}
