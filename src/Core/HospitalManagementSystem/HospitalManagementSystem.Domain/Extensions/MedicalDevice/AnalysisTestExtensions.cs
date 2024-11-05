namespace HospitalManagementSystem.Domain;

public static class AnalysisTestExtensions
{
    public static AnalysisTest RemoveRelated(this AnalysisTest analysisTest)
    {
        analysisTest.DeviceInventory = null!;
        analysisTest.MedicalExamEpisode = null!;
        return analysisTest;
    }
}
