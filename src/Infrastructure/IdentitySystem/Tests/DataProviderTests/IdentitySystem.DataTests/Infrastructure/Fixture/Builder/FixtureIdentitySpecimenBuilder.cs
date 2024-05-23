namespace IdentitySystem.Tests;

public class FixtureIdentitySpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var pi = request as PropertyInfo;
        if (pi != null)
        {
            var isIdentityType = 
                   typeof(IdentityUser<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityRole<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserClaim<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserRole<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserLogin<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserToken<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityRoleClaim<string>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUser<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityRole<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserClaim<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserRole<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserLogin<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserToken<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityRoleClaim<string>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUser<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityRole<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserClaim<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserRole<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserLogin<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityUserToken<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IdentityRoleClaim<Guid>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUser<Guid>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityRole<Guid>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserClaim<Guid>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserRole<Guid>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserLogin<Guid>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityUserToken<Guid>>).IsAssignableFrom(pi.PropertyType)
                || typeof(IEnumerable<IdentityRoleClaim<Guid>>).IsAssignableFrom(pi.PropertyType);

            if (isIdentityType)
            {
                return new OmitSpecimen();
            }
        }

        return new NoSpecimen();
    }
}
