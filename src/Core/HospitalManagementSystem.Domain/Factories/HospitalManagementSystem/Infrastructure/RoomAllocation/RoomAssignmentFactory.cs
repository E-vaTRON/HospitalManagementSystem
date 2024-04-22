namespace HospitalManagementSystem.Domain;

public static class RoomAssignmentFactory
{
    public static RoomAllocation Create()
    {
        return new RoomAllocation();
    }

    public static RoomAllocation Create(DateTime startTime, DateTime endTime, string patientId, string roomId, string medicalExamEposodeId)
    {
        return new RoomAllocation()
        {
            StartTime = startTime,
            EndTime = endTime,
            PatientId = patientId,
            RoomId = roomId,
            MedicalExamEposodeId = medicalExamEposodeId
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
