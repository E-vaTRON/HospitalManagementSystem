namespace HospitalManagementSystem.Application;

public record OutputRoomAllocationDTO : RoomAllocationDTO
{
    public OutputRoomDTO?                 Room                 { get; init; }
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisode   { get; init; }
}