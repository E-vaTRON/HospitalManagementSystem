namespace HospitalManagementSystem.Domain;

public static class RoomAllocationExtensions
{
    public static RoomAllocation RemoveRelated(this RoomAllocation roomAllocation)
    {
        roomAllocation.Room = null!;
        roomAllocation.MedicalExamEpisode = null!;
        return roomAllocation;
    }
}
