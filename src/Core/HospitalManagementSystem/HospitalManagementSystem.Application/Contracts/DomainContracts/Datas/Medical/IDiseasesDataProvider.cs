namespace HospitalManagementSystem.Application;

public interface IDiseasesDataProvider : IDataProviderBase<Diseases, string>
{
    Task<IEnumerable<Diseases>> FindAllWithIncludeAsync(CancellationToken cancellationToken = default!);
}
