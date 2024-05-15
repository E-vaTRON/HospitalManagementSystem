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
    #endregion
}
