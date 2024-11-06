namespace HospitalManagementSystem.Domain;

public static class AnalysisTestFactory
{
    public static AnalysisTest Create()
    {
        return new AnalysisTest();
    }

    public static AnalysisTest Create(string doctorComment, string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return new AnalysisTest()
        {
            DoctorComment = doctorComment,
            ResultSummary = resultSummary,
            SpecificMeasurements = specificMeasurements,
            UserId = userId,
            TechnicianSignature = technicianSignature
        };
    }

    public static AnalysisTest Create(string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return new AnalysisTest()
        {
            DoctorComment = string.Empty,
            ResultSummary = resultSummary,
            SpecificMeasurements = specificMeasurements,
            UserId = userId,
            TechnicianSignature = technicianSignature
        };
    }
}