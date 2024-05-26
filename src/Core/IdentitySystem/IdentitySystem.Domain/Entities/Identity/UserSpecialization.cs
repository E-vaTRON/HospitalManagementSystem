namespace IdentitySystem.Domain;

public class UserSpecialization : EntityBase
{
    public string?          UserId              { get; set; }
    public User?            User                { get; set; }
    public string?          SpecializationId    { get; set; }
    public Specialization?  Specialization      { get; set; }
}
