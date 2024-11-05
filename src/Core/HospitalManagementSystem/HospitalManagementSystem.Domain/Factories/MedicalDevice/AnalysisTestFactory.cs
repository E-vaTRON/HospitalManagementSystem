namespace HospitalManagementSystem.Domain;

public static class AnalysisTestFactory
{
    public static AnalysisTest Create()
    {
        return new AnalysisTest();
    }

    public static AnalysisTest Create(string doctorComment, string resultSummary)
    {
        return new AnalysisTest()
        {
            DoctorComment = doctorComment,
            ResultSummary = resultSummary,
        };
    }

    public static AnalysisTest Create(string resultSummary)
    {
        return new AnalysisTest()
        {
            DoctorComment = string.Empty,
            ResultSummary = resultSummary,
        };
    }
}