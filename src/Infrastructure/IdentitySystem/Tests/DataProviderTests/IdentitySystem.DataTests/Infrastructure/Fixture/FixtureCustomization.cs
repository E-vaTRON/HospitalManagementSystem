namespace IdentitySystem.Tests;

public  class FixtureCustomization : ICustomization
{
    private readonly IPasswordHasher<DataProvider.User> PasswordHasher;

    public FixtureCustomization()
    {
        PasswordHasher = new PasswordHasher<DataProvider.User>();
    }

    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new FixtureIdentitySpecimenBuilder());
        fixture.Customizations.Add(new FixtureEntitySpecimenBuilder());
        fixture.Customizations.Add(new FixtureModelSpecimenBuilder());
        fixture.Customizations.Add(new FixturePropertiesRemoveSpecimenBuilder());

        var userName = fixture.Create<string>();
        var roleName = fixture.Create<string>();
        var email = fixture.Create<MailAddress>().Address;
        var password = fixture.Create<string>();

        fixture.Customize<DataProvider.User>(user => user
            .Without(u => u.PasswordHash)
            .Without(u => u.NormalizedUserName)
            .Without(u => u.NormalizedEmail)
            .With(u => u.UserName, userName)
            .With(u => u.Email, email)
            .Do(u => u.PasswordHash = PasswordHasher.HashPassword(u, password))
            .Do(u => u.NormalizedUserName = userName.ToUpper())
            .Do(u => u.NormalizedEmail = email.ToUpper()));

        fixture.Customize<Domain.User>(user => user
            .Without(u => u.PasswordHash)
            .Without(u => u.NormalizedUserName)
            .Without(u => u.NormalizedEmail)
            .With(u => u.UserName, userName)
            .With(u => u.Email, email));

        fixture.Customize<DataProvider.Role>(role => role
            .Without(r => r.NormalizedName)
            .With(r => r.Name, roleName)
            .Do(u => u.NormalizedName = roleName.ToUpper()));

        fixture.Customize<Domain.Role>(role => role
            .Without(r => r.NormalizedName)
            .With(r => r.Name, roleName));
    }
}
