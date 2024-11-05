namespace HospitalManagementSystem.Domain;

public static class ReExamAppointmentExtensions
{
    public static ReExamAppointment RemoveRelated(this ReExamAppointment reExamAppointment)
    {
        reExamAppointment.MedicalExamEpisode = null!;
        return reExamAppointment;
    }
}
