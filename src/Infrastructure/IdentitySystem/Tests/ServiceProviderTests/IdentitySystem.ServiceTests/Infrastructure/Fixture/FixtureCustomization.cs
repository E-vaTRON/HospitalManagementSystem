namespace IdentitySystem.Tests;

public  class FixtureCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new EntitySpecimenBuilder());
        fixture.Customizations.Add(new ModelSpecimenBuilder());
        fixture.Customizations.Add(new PropertiesRemoveSpecimenBuilder());
    }
}
