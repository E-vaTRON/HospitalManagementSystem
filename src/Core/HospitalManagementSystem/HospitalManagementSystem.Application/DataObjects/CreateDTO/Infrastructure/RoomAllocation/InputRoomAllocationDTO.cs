namespace HospitalManagementSystem.Application;

public record InputRoomAllocationDTO : RoomAllocationDTO
{
    public string? RoomDTOId                { get; init; }
    public string? MedicalExamEpisodeDTOId  { get; init; }
}