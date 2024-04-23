namespace HospitalManagementSystem.Domain;

public static class ReExamAppointmentFactory
{
    #region [ Methods ]
    public static ReExamAppointment Create()
    {
        return new ReExamAppointment();
    }

    public static ReExamAppointment Create(string patientId, string medicalExamEposodeId, string notes, DateTime dateTime)
    {
        return new ReExamAppointment()
        {
            AppointmentDate = dateTime,
            MedicalExamEposodeId = medicalExamEposodeId,
            PatientId = patientId,
            Notes = notes
        };
    }

    public static ReExamAppointment Create(string patientId, string medicalExamEposodeId, string notes)
    {
        return new ReExamAppointment()
        {
            AppointmentDate = DateTime.Now,
            MedicalExamEposodeId = medicalExamEposodeId,
            PatientId = patientId,
            Notes = notes
        };
    }
    #endregion
}
