namespace HospitalManagementSystem.Domain;

public static class RoomAllocationFactory
{
    public static RoomAllocation Create()
    {
        return new RoomAllocation();
    }

    public static RoomAllocation Create(DateTime startTime, DateTime endTime, string patientId, string employeeId)
    {
        return new RoomAllocation()
        {
            StartTime = startTime,
            EndTime = endTime,
            PatientId = patientId,
            EmployeeId = employeeId
        };
    }
}