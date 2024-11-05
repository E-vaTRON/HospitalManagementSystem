namespace HospitalManagementSystem.Application;

public interface IDiseasesServiceProvider : IServiceProviderBase<OutputDiseasesDTO, InputDiseasesDTO, string>
{
    //Task<IEnumerable<OutputDiseasesDTO>> FindAllWithIncludeAsync(CancellationToken cancellationToken = default!);
}
