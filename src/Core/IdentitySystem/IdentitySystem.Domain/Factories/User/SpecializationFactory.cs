namespace IdentitySystem.Domain;

public static class SpecializationFactory
{
    public static Specialization Create()
    {
        return new Specialization();
    }

    public static Specialization Create(string name, string description)
    {
        return new Specialization()
        {
            Name = name,
            Description = description
        };
    }

}
