namespace HospitalManagementSystem.Domain;

public static class ServiceEpisodeExtensions
{
    #region [ Private Methods ]
    #endregion

    #region [ Public Methods ]
    public static ServiceEpisode RemoveRelated(this ServiceEpisode deviceService)
    {
        deviceService.MedicalExamEpisode = null!;
        deviceService.MedicalService = null!;
        return deviceService;
    }
    #endregion
}
