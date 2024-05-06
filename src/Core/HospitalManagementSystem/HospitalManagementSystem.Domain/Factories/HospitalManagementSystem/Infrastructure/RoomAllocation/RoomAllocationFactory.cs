namespace HospitalManagementSystem.Domain;

public static class RoomAllocationFactory
{
    public static RoomAllocation Create()
    {
        return new RoomAllocation();
    }

    public static RoomAllocation Create(DateTime startTime, DateTime endTime, string patientId, string roomId, string medicalExamEpisodeId)
    {
        return new RoomAllocation()
        {
            StartTime = startTime,
            EndTime = endTime,
            PatientId = patientId,
            RoomId = roomId,
            MedicalExamEpisodeId = medicalExamEpisodeId
        };
    }

    public static RoomAllocation Create(DateTime endTime, string patientId, string roomId)
    {
        return new RoomAllocation()
        {
            StartTime = DateTime.Now,
            EndTime = endTime,
            PatientId = patientId,
            RoomId = roomId
        };
    }
}