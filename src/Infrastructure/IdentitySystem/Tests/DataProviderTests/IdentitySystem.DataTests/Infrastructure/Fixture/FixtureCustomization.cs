namespace IdentitySystem.Tests;

public  class FixtureCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new FixtureIdentitySpecimenBuilder());
        fixture.Customizations.Add(new FixtureEntitySpecimenBuilder());
        fixture.Customizations.Add(new FixtureModelSpecimenBuilder());
        fixture.Customizations.Add(new FixturePropertiesRemoveSpecimenBuilder());
    }
}
