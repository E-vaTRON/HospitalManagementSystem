namespace HospitalManagementSystem.Domain;

public class RoomFactory : EntityBase
{
    public static Room Create()
    {
        return new Room();
    }

    public static Room Create(string name, RoomType roomType, int capacity)
    {
        return new Room()
        {
            Name = name,
            RoomType = roomType,
            Capacity = capacity,
        };
    }

    public static Room Create(string name, RoomType roomType, int capacity, string departmentId)
    {
        return new Room()
        {
            Name = name,
            RoomType = roomType,
            Capacity = capacity,
            DepartmentId = departmentId
        };
    }
}