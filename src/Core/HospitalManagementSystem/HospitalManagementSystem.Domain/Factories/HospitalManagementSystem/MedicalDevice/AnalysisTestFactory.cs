namespace HospitalManagementSystem.Domain;

public static class AnalysisTestFactory
{
    public static AnalysisTest Create()
    {
        return new AnalysisTest();
    }

    public static AnalysisTest Create(string doctorComment, string result, string deviceServiceId, string medicalExamEpisodeId)
    {
        return new AnalysisTest()
        {
            DoctorComment = doctorComment,
            Result = result,
            DeviceServiceId = deviceServiceId,
            MedicalExamEpisodeId = medicalExamEpisodeId
        };
    }

    public static AnalysisTest Create(string result, string deviceServiceId, string medicalExamEpisodeId)
    {
        return new AnalysisTest()
        {
            DoctorComment = string.Empty,
            Result = result,
            DeviceServiceId = deviceServiceId,
            MedicalExamEpisodeId = medicalExamEpisodeId
        };
    }
}