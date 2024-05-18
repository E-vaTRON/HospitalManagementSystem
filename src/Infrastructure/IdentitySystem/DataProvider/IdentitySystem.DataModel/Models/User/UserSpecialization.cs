namespace IdentitySystem.DataProvider;

public class UserSpecialization : ModelBase
{
    public Guid             UserId              { get; set; }
    public User?            User                { get; set; }
    public Guid             SpecializationId    { get; set; }
    public Specialization?  Specialization      { get; set; }
}
