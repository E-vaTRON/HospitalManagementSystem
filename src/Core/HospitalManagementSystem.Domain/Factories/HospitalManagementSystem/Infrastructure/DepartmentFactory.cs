namespace HospitalManagementSystem.Domain;

public static class DepartmentFactory
{
    public static Department Create()
    {
        return new Department();
    }

    public static Department Create(string name)
    {
        return new Department()
        {
            Name = name
        };
    }
}
