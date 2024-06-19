namespace HospitalManagementSystem.Domain;

public static class RoomExtensions
{
    #region [ Private Methods ]
    private static Room AddRoomAllocation(this Room room, RoomAllocation roomAllocation)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(roomAllocation));

        if (room.RoomAllocations.Any(x => x.Id == roomAllocation.Id))
        {
            return room;
        }

        roomAllocation.RoomId = room.Id;
        roomAllocation.Room = room;
        room.RoomAllocations.Add(roomAllocation);
        return room;
    }
    #endregion

    #region [ Public Methods ]
    public static Room AddRoomAllocation(this Room room)
    {
        return room.AddRoomAllocation(RoomAllocationFactory.Create());
    }

    public static Room AddRoomAllocation(this Room room, DateTime endTime, string patientId, string employeeId, string roomId)
    {
        return room.AddRoomAllocation(RoomAllocationFactory.Create(endTime, patientId, employeeId, roomId));
    }

    public static Room AddRoomAllocation(this Room room, DateTime startTime, DateTime endTime, string patientId, string employeeId, string roomId, string medicalExamEpisodeId)
    {
        return room.AddRoomAllocation(RoomAllocationFactory.Create(startTime, endTime, patientId, employeeId, roomId, medicalExamEpisodeId));
    }
    #endregion
}
