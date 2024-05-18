namespace IdentitySystem.Tests;

public class PropertiesRemoveSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var propertyInfo = request as PropertyInfo;
        if (propertyInfo != null)
        {
            if (propertyInfo.Name == "IsDeleted")
            {
                return new OmitSpecimen();
            }
        }

        return new NoSpecimen();
    }
}
