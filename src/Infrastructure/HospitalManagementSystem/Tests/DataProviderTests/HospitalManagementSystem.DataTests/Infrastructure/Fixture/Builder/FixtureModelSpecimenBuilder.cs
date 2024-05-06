namespace HospitalManagementSystem.Tests;

public class FixtureModelSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var pi = request as PropertyInfo;
        if (pi != null)
        {
            var isDomainModel = typeof(IModel).IsAssignableFrom(pi.PropertyType);
            var isDomainModelCollection = typeof(IEnumerable<IModel>).IsAssignableFrom(pi.PropertyType);
            if (isDomainModel || isDomainModelCollection)
            {
                return new OmitSpecimen();
            }
        }

        return new NoSpecimen();
    }
}
