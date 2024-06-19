namespace HospitalManagementSystem.Domain;

public static class DeviceServiceExtensions
{
    #region [ Private Methods ]
    private static DeviceService AddAnalysisTest(this DeviceService deviceService, AnalysisTest analysisTest)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(analysisTest));

        // Assuming DeviceServiceId and MedicalExamEpisodeId together should be unique
        if (deviceService.AnalysisTests.Any(at => at.DeviceServiceId == analysisTest.DeviceServiceId && at.MedicalExamEpisodeId == analysisTest.MedicalExamEpisodeId))
        {
            return deviceService;
        }

        analysisTest.DeviceServiceId = deviceService.Id;
        analysisTest.DeviceService = deviceService;
        deviceService.AnalysisTests.Add(analysisTest);
        return deviceService;
    }
    #endregion

    #region [ Public Methods ]
    public static DeviceService AddAnalysisTest(this DeviceService deviceService)
    {
        return deviceService.AddAnalysisTest(AnalysisTestFactory.Create());
    }

    public static DeviceService AddAnalysisTest(this DeviceService deviceService, string doctorComment, string result, string deviceServiceId, string medicalExamEpisodeId)
    {
        return deviceService.AddAnalysisTest(AnalysisTestFactory.Create(doctorComment, result, deviceServiceId, medicalExamEpisodeId));
    }

    public static DeviceService AddAnalysisTest(this DeviceService deviceService, string result, string deviceServiceId, string medicalExamEpisodeId)
    {
        return deviceService.AddAnalysisTest(AnalysisTestFactory.Create(result, deviceServiceId, medicalExamEpisodeId));
    }
    #endregion
}
