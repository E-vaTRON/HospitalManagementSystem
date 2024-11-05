using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.DataProvider;

public static class SeedProviderHelpers
{
    #region [ Seed ]
    public static async Task SeedAsync<TEntity, TEId>(this IDataProviderBase<TEntity, TEId> dataProvider, List<TEntity> entities, bool onlySeedIfEmpty = true)
        where TEntity : class, IEntity<TEId>
    {

        var dbResults = await dataProvider.FindAllAsync();
        if (dbResults.Any() && onlySeedIfEmpty)
        {
            return;
        }

        foreach (var entity in entities)
        {
            await dataProvider.AddAsync(entity);
        }
    }

    public static async Task SeedIdentityAsync<TEntity, TEId>(this IIdentityDataProviderBase<TEntity, TEId> dataProvider, List<TEntity> entities, bool onlySeedIfEmpty = true)
        where TEntity : class
    {

        var dbResults = await dataProvider.FindAll().ToListAsync();
        if (dbResults.Any() && onlySeedIfEmpty)
        {
            return;
        }

        if (dataProvider is IUserDataProvider userDataProvider)
        {
            foreach (var entity in entities)
            {
                if (entity is Domain.User user)
                    await userDataProvider.CreateAsync(user, "12345");
            }
        }

        if (dataProvider is IRoleDataProvider roleDataProvider)
        {
            foreach (var entity in entities)
            {
                if (entity is Domain.Role role)
                    await roleDataProvider.CreateAsync(role);
            }
        }
    }
    #endregion
}
