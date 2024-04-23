namespace HospitalManagementSystem.Domain;

public static class MedicalExamFactory
{
    public static MedicalExam Create()
    {
        return new MedicalExam();
    }

    public static MedicalExam Create(int? finalPrice, string bookingAppointmentId)
    {
        return new MedicalExam()
        {
            FinalPrice = finalPrice,
            BookingAppointmentId = bookingAppointmentId
        };
    }
}