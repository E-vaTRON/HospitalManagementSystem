namespace HospitalManagementSystem.DataProvider;

public static class SeedProviderHelpers
{
    #region [ Seed ]
    public static async Task SeedAsync<TEntity, TModel>(this DbSet<TModel> dbSet, List<TEntity> domainEntities, IMapper mapper, bool onlySeedIfEmpty = true)
        where TEntity : class
        where TModel : class
    { 
        var dbResults = await dbSet.ToListAsync(); 
        if (dbResults.Any() && onlySeedIfEmpty) 
        { 
            return;
        }

        var dataEntities = mapper.Map<List<TModel>>(domainEntities);
        await dbSet.AddRangeAsync(dataEntities);
    }
    #endregion
}
