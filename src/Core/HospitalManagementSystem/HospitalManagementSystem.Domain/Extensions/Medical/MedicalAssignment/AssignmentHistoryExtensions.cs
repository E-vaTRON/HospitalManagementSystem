namespace HospitalManagementSystem.Domain;

public static class AssignmentHistoryExtensions
{
    public static AssignmentHistory RemoveRelated(this AssignmentHistory assignmentHistory)
    {
        assignmentHistory.MedicalExamEpisode = null!;
        assignmentHistory.ReferralDoctor = null!;
        return assignmentHistory;
    }
}
