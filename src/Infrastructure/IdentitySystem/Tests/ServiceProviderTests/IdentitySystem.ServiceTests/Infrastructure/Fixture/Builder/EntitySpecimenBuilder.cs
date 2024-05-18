namespace IdentitySystem.Tests;

public class EntitySpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var pi = request as PropertyInfo;
        if (pi != null)
        {
            var isEntity = typeof(IEntity).IsAssignableFrom(pi.PropertyType);
            var isEntityCollection = typeof(IEnumerable<IEntity>).IsAssignableFrom(pi.PropertyType);
            if (isEntity || isEntityCollection)
            {
                return new OmitSpecimen();
            }
        }

        return new NoSpecimen();
    }
}
