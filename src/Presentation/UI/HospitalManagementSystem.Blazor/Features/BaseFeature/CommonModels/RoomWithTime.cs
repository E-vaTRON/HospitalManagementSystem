namespace HospitalManagementSystem.Blazor;

public record RoomWithTime : OutputRoomDTO
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}