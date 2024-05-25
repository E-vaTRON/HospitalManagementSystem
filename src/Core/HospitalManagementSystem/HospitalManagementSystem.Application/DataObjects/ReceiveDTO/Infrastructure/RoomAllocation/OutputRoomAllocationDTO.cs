namespace HospitalManagementSystem.Application;

public record OutputRoomAllocationDTO : RoomAllocationDTO
{
    public RoomDTO?                 RoomDTO                 { get; set; }
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; set; }
}