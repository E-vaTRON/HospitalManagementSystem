namespace HospitalManagementSystem.Domain;

public static class ReExamAppointmentFactory
{
    #region [ Methods ]
    public static ReExamAppointment Create()
    {
        return new ReExamAppointment();
    }

    public static ReExamAppointment Create(string patientId, string notes, DateTime dateTime)
    {
        return new ReExamAppointment()
        {
            AppointmentDate = dateTime,
            PatientId = patientId,
            Notes = notes
        };
    }

    public static ReExamAppointment Create(string patientId, string notes)
    {
        return new ReExamAppointment()
        {
            AppointmentDate = DateTime.Now,
            PatientId = patientId,
            Notes = notes
        };
    }
    #endregion
}
