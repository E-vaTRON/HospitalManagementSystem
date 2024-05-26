namespace HospitalManagementSystem.Application;

public record OutputRoomAllocationDTO : RoomAllocationDTO
{
    public RoomDTO?                 RoomDTO                 { get; init; }
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
}