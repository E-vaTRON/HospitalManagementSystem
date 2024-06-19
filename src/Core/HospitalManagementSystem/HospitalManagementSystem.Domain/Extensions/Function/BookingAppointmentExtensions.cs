namespace HospitalManagementSystem.Domain;

public static class BookingAppointmentExtensions
{
    #region [ Private Methods ]
    private static BookingAppointment AddMedicalExam(this BookingAppointment bookingAppointment, MedicalExam medicalExam)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(medicalExam));

        if (bookingAppointment.MedicalExam is null)
        {
            return bookingAppointment;
        }

        medicalExam.BookingAppointmentId = bookingAppointment.Id;
        medicalExam.BookingAppointment = bookingAppointment;
        bookingAppointment.MedicalExam = medicalExam;
        return bookingAppointment;
    }
    #endregion

    #region [ Public Methods ]
    public static BookingAppointment AddMedicalExam(this BookingAppointment bookingAppointment)
    {
        return bookingAppointment.AddMedicalExam(MedicalExamFactory.Create());
    }
    #endregion
}
