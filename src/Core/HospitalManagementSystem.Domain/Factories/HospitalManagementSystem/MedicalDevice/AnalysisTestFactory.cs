namespace HospitalManagementSystem.Domain;

public static class AnalysisTestFactory
{
    public static AnalysisTest Create()
    {
        return new AnalysisTest();
    }

    public static AnalysisTest Create(string dSymptom, string doctorComment, string result, string deviceServiceId, string medicalExamEposodeId)
    {
        return new AnalysisTest()
        {
            DSymptom = dSymptom,
            DoctorComment = doctorComment,
            Result = result,
            DeviceServiceId = deviceServiceId,
            MedicalExamEposodeId = medicalExamEposodeId
        };
    }

    public static AnalysisTest Create(string result, string deviceServiceId, string medicalExamEposodeId)
    {
        return new AnalysisTest()
        {
            DSymptom = string.Empty,
            DoctorComment = string.Empty,
            Result = result,
            DeviceServiceId = deviceServiceId,
            MedicalExamEposodeId = medicalExamEposodeId
        };
    }
}