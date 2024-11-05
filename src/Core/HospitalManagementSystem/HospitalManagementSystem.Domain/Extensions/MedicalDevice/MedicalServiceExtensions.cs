namespace HospitalManagementSystem.Domain;

public static class MedicalServiceExtensions
{
    #region [ Private Methods ]
    private static MedicalService AddServiceEpisode(this MedicalService medicalService, ServiceEpisode serviceEpisode)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(serviceEpisode));

        // Assuming DeviceInventoryId and ServiceId together should be unique
        if (medicalService.ServiceEpisodes.Any(x => x.Id == serviceEpisode.Id))
        {
            return medicalService;
        }

        serviceEpisode.MedicalServiceId = medicalService.Id;
        serviceEpisode.MedicalService = medicalService;
        medicalService.ServiceEpisodes.Add(serviceEpisode);
        return medicalService;
    }
    #endregion

    #region [ Public Methods ]
    public static MedicalService AddServiceEpisode(this MedicalService medicalService)
    {
        return medicalService.AddServiceEpisode(ServiceEpisodeFactory.Create());
    }

    public static MedicalService RemoveRelated(this MedicalService medicalService)
    {
        medicalService.ServiceEpisodes.Clear();
        return medicalService;
    }
    #endregion
}
