namespace HospitalManagementSystem.Domain;

public static class BookingAppointmentFactory
{
    #region [ Methods ]
    public static BookingAppointment Create()
    {
        return new BookingAppointment();
    }

    public static BookingAppointment Create(string doctorId, string patientId, string medicalExamId, string notes, DateTime dateTime)
    {
        return new BookingAppointment()
        {
            AppointmentDate = dateTime,
            MedicalExamId = medicalExamId,
            PatientId = patientId,
            DoctorId = doctorId,
            Notes = notes
        };
    }

    public static BookingAppointment Create(string patientId, string doctorId, string medicalExamId, string notes)
    {
        return new BookingAppointment()
        {
            AppointmentDate = DateTime.Now,
            MedicalExamId = medicalExamId,
            PatientId = patientId,
            DoctorId = doctorId,
            Notes = notes
        };
    }
    #endregion
}
