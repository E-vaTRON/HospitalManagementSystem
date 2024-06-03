namespace HospitalManagementSystem.Application;

public record RoomDTO : DTOBase
{
    public string       Name            { get; init; } = string.Empty;
    public RoomType     RoomType        { get; init; }
    public int          Capacity        { get; init; }
    public RoomStatus   Status          { get; init; }
    public int          PricePerHour    { get; init; }
}