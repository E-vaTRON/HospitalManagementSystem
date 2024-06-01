namespace HospitalManagementSystem.Application;

public record OutputRoomAllocationDTO : RoomAllocationDTO
{
    public OutputRoomDTO?                 RoomDTO                 { get; init; }
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
}