namespace IdentitySystem.DataProvider;

public static class SeedProviderHelpers
{
    #region [ Seed ]
    public static async Task SeedAsync<TEntity, TModel>(this DbSet<TModel> dbSet, List<TEntity> domainEntities, IMapper mapper,  bool onlySeedIfEmpty = true)
        where TEntity : class
        where TModel : class
    {
        var dbResults = await dbSet.ToListAsync();
        if (dbResults.Any() && onlySeedIfEmpty)
        {
            return;
        }

        var dataEntities = mapper.Map<List<TModel>>(domainEntities);

        if (typeof(TModel) != typeof(User)) 
        {
            await dbSet.AddRangeAsync(dataEntities);
        } 
        else 
        {
            var passwordHasher = new PasswordHasher<User>();
            foreach (var entity in dataEntities)
            {
                if (entity is User user)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, "12345");
                }
            }
            await dbSet.AddRangeAsync(dataEntities);
        }
    }
    #endregion
}
