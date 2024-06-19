namespace HospitalManagementSystem.Domain;

public static class DepartmentExtensions
{
    #region [ Private Methods ]
    private static Department AddRoom(this Department department, Room room)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(room));

        if (department.Rooms.Any(x => x.Id == room.Id))
        {
            return department;
        }

        room.DepartmentId = department.Id;
        room.Department = department;
        department.Rooms.Add(room);
        return department;
    }
    #endregion

    #region [ Public Methods ]
    public static Department AddRoom(this Department department)
    {
        return department.AddRoom(RoomFactory.Create());
    }

    public static Department AddRoom(this Department department, string name, RoomType roomType, int capacity)
    {
        return department.AddRoom(RoomFactory.Create(name, roomType, capacity));
    }

    public static Department AddRoom(this Department department, string name, RoomType roomType, int capacity, string departmentId)
    {
        return department.AddRoom(RoomFactory.Create(name, roomType, capacity, departmentId));
    }
    #endregion
}
