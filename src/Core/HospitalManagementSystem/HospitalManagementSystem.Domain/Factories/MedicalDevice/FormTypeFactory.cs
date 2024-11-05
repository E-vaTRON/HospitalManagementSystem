namespace HospitalManagementSystem.Domain;

public static class FormTypeFactory
{
    public static FormType Create()
    {
        return new FormType();
    }
    public static FormType Create(string name, string description, string documentPath)
    {
        return new FormType
        {
            Name = name,
            Description = description,
            DocumentPath = documentPath
        };
    }
}
